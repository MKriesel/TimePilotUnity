using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bomb : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        //Debug.Log(direction.normalized);
        direction.Normalize();
        rb.velocity = new Vector2(direction.x  * 3f, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "0Bull" || collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
