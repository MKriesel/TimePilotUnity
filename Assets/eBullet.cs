using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet : MonoBehaviour
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
        rb.velocity = new Vector2(direction.x  , direction.y)*2.5f;
    }
}
