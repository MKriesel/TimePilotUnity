using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    private float livesLeft = 2f;
    [SerializeField] private Text lives;


    public GameObject bullet;
    public GameObject bullPos;
    private PolygonCollider2D col;


    private float shootTimer;
    private bool shooting = false;
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<PolygonCollider2D>();
        shootTimer = 0.2f;
    }

    void Update()
    {

        float sin = Mathf.Sin(Mathf.PI * transform.localEulerAngles.z/180f);
        float cos = Mathf.Cos(Mathf.PI * transform.localEulerAngles.z/180f);
        
        var d = new Vector3(sin*-1, cos, 0);

        //movement
        transform.position += (d * 2.5f * Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Debug.Log(x + "  " + y);
            
        //turning
        var lookDirection = new Vector2(x, y);
        lookDirection.Normalize();
        if(lookDirection != Vector2.zero){
            Quaternion targetRot = Quaternion.LookRotation(Vector3.forward, lookDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRot, 1.2f);
            //Debug.Log();
        }
        
        if(shooting == false && (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))){
            shooting = true;
            StartCoroutine(shoot());
        }
    }
    
    private IEnumerator shoot()
    {
        
        Instantiate(bullet, bullPos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, bullPos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, bullPos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        shooting = false;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bomb" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "eBull" || collision.gameObject.tag == "bb" )
        {
            Debug.Log(collision.gameObject.tag);
            //Destroy(gameObject);
            livesLeft -= 1f;
            lives.text = livesLeft.ToString();
            //destory enemies
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
            //wait second

            //move back to 00
            transform.position = new Vector2(0,0);
        }
    }
}
