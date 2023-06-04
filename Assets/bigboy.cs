using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigboy : MonoBehaviour
{
    public float health = 15f;
    private BoxCollider2D col;
    void Start()
    {
         col = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        move();
    }

    void move(){
        float sin = Mathf.Sin(Mathf.PI * transform.localEulerAngles.z/180f);
        float cos = Mathf.Cos(Mathf.PI * transform.localEulerAngles.z/180f);
        
        var d = new Vector3(cos,sin, 0);
        //Debug.Log(d);
        transform.position += (d * 1f * Time.deltaTime);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(health);
        if (collision.gameObject.tag == "0Bull" )
        {
            if (health == 0f){
                Destroy(gameObject);
                //level up
            } else {
                health -= 1f;
            }
        }
        if (collision.gameObject.tag == "0Bull" )
        {
            Destroy(gameObject);
            //level up
        }
    }
}
