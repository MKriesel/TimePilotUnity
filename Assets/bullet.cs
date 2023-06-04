using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    void Start()
    {
        col = this.GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


        float sin = Mathf.Sin(Mathf.PI * player.transform.localEulerAngles.z/180f);
        float cos = Mathf.Cos(Mathf.PI * player.transform.localEulerAngles.z/180f);
        
        var d = new Vector3(sin*-1, cos, 0);

        rb.velocity = new Vector2(d.x, d.y).normalized * 7f;


        Vector3 dir = player.transform.position - transform.position;
        if(Mathf.Abs(dir.x) > 6f || Mathf.Abs(dir.y) > 6f){
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
