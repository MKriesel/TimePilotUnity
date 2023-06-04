using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plane40 : MonoBehaviour
{
    /*
    when enemy created 
        give spawn direction
        give assignment(s)

    */

    //[SerializeField] private Transform player;
    
    private Transform player;
    public GameObject bomba;
    public GameObject bullet;
    public GameObject bullSpawn;
    private Rigidbody2D rb;
    private PolygonCollider2D col;
    private Vector2 movement;
    private Vector2 lookDirection = new Vector2(0f,0f);
    private float bombTimer;
    private float bulletTimer;
    private float moveTimer;

    private float bombTimerRan;
    private float bulletTimerRan;
    private float moveTimerRan;

    private float bomber;
    private float shooter;
    private float follower;
    private float none;

    private spawner ren;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<PolygonCollider2D>();
        ren = GameObject.FindGameObjectWithTag("render").GetComponent<spawner>();

        //assign roles
        bomber = Random.Range(0, 5);
        shooter = Random.Range(0, 3);
        follower = Random.Range(0, 4);


        //Debug.Log(bomber + " " + shooter + " " + follower);
        //none = Random.Range(0, 1);


        bombTimerRan = Random.Range(3f,8f);
        bulletTimerRan = Random.Range(2f,4f);
        moveTimerRan = Random.Range(2f,8f);
        //Debug.Log(bombTimerRan + " " + bulletTimerRan + " " + moveTimerRan);
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = player.position - transform.position;


        if(follower == 1){
            if(Mathf.Abs(dir.x) < 3.5f && Mathf.Abs(dir.y) < 3.5f){
                lookDirection = new Vector2(dir.x , dir.y);
            }
        } else{
            moveTimer += Time.deltaTime;
            if(moveTimer > moveTimerRan){
                //Debug.Log("turn");
                moveTimerRan = Random.Range(3f,6f);
                moveTimer = 0;
                lookDirection = new Vector2(Random.Range(-1,1) , Random.Range(-1,1));
            }
        }
        bombTimer += Time.deltaTime;
        bulletTimer += Time.deltaTime;
        move();
        turn(lookDirection);
        
        if(bomber == 1){
            bomb();
        }
        if(shooter == 1){
            shoot();
        }
        

        //if plane is too far away, destroy
        if(Mathf.Abs(dir.x) > 6f || Mathf.Abs(dir.y) > 6f){
            Destroy(gameObject);
        }
    }

    void turn(Vector2 lookDirection){
        lookDirection.Normalize();
        if(lookDirection != Vector2.zero){
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, lookDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRot,0.3f);
            //Debug.Log();
        }
        
    }
    void move(){
        float sin = Mathf.Sin(Mathf.PI * transform.localEulerAngles.z/180f);
        float cos = Mathf.Cos(Mathf.PI * transform.localEulerAngles.z/180f);
        
        var d = new Vector3(sin*-1, cos, 0);
        //Debug.Log(d);
        transform.position += (d * 0.7f * Time.deltaTime);
        
    }
    void bomb(){
        if(bombTimer > bombTimerRan && player.position.y < transform.position.y + 1){
            bombTimerRan = Random.Range(2f,5f);
        
            bombTimer = 0;
            Instantiate(bomba, transform.position, Quaternion.identity);
        }
    }
    void shoot(){
        if(bulletTimer > bulletTimerRan){
            bulletTimerRan = Random.Range(2f,4f);
            bulletTimer = 0;
            Instantiate(bullet, bullSpawn.transform.position, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "0Bull" || collision.gameObject.tag == "Player" )
        {
            
            //GameObject.FindGameObjectWithTag("render").GetComponent<spawner>().updateScores();
            ren.updateEnemiesLeft();
            ren.updateScores();
            Destroy(gameObject);
            
        }
    }
}
