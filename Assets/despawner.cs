using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawner : MonoBehaviour
{
    private spawner ren;

     void Start()
    {
        ren = GameObject.FindGameObjectWithTag("render").GetComponent<spawner>();
    }
    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "bb"){
            ren.respawnbb();
        } else {
            Destroy(collision.gameObject);
        }
    }
}
