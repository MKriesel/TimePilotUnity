using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player;

    void Update () 
    {
        transform.position = new Vector3 (player.position.x , player.position.y , -10); // Camera follows the player with specified offset position
    }
}
