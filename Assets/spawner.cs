using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text enemiesText;
    private float enemiesLeft = 56;
    private float scores = 0;

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject bb;
    [SerializeField] private GameObject fleet;
    //private Transform player;
    private bool canSpawn = true;
    private BoxCollider2D col;
    private  Vector2 targetRot;
    private bool bbSpawned = false; 
    
    void Start()
    {
        col = this.GetComponent<BoxCollider2D>();
        StartCoroutine(spawnSmall());
        
    }

    void Update()
    {
        //var y = col.size.y - col.p.y;
        //Debug.Log(col.bounds);
        if(enemiesLeft == 0f && bbSpawned == false){
            Vector3 spawnPos = spawnArea(1);//spawnArea(Random.Range(0,4));
            Debug.Log("big boy in the hizzoues");
            targetRot = new Vector2(0,1);
            Vector3 area = new Vector3(Random.Range(col.bounds.center.x - 4f, col.bounds.center.x - col.bounds.extents.x )
            , Random.Range(col.bounds.center.y - col.bounds.extents.y, col.bounds.center.y + col.bounds.extents.y ),0);
                
            Instantiate(bb, new Vector3(area.x,area.y,0), Quaternion.LookRotation(Vector3.forward, targetRot));
            bbSpawned = true;
        }
    }

    private IEnumerator spawnSmall(){
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (canSpawn){
            yield return wait;
            Vector3 spawnPos = spawnArea(Random.Range(0,4));
            //determineRotation(spawnPos);
            int ran = Random.Range(0,15);
            //Debug.Log(ran);
            if(ran == 4){
                    Instantiate(enemy, new Vector3(spawnPos.x,spawnPos.y,0), Quaternion.LookRotation(Vector3.forward, targetRot));
                    Instantiate(enemy, new Vector3(spawnPos.x-.5f,spawnPos.y+.4f,0), Quaternion.LookRotation(Vector3.forward, targetRot));
                    Instantiate(enemy, new Vector3(spawnPos.x-.5f,spawnPos.y-.4f,0), Quaternion.LookRotation(Vector3.forward, targetRot));
                    Instantiate(enemy, new Vector3(spawnPos.x-.9f,spawnPos.y+.8f,0), Quaternion.LookRotation(Vector3.forward, targetRot));
                    Instantiate(enemy, new Vector3(spawnPos.x-.9f,spawnPos.y-.8f,0), Quaternion.LookRotation(Vector3.forward, targetRot));
                } else{
                    Instantiate(enemy, spawnPos, Quaternion.LookRotation(Vector3.forward, targetRot));
            }
        }
    }

    private void determineRotation(Vector3 enemy){
        Vector3 dir = transform.position - enemy;
        var lookDirection = new Vector2(dir.x , dir.y);
    
        if(lookDirection != Vector2.zero){
            //targetRot = Quaternion.LookRotation(Vector3.forward, lookDirection);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRot,0.5f);
            //Debug.Log();
        }
    }
    private Vector3 spawnArea(int c){
        Vector3 area = new Vector3(0,0,0);
        switch(c){
            //right
            case 0:
                targetRot = new Vector2(-1,0);
                area = new Vector3(Random.Range(col.bounds.center.x + 4f, col.bounds.center.x + col.bounds.extents.x )
                , Random.Range(col.bounds.center.y - col.bounds.extents.y, col.bounds.center.y + col.bounds.extents.y ),0);
                break;
            //left
            case 1:
                targetRot = new Vector2(1,0);
                area = new Vector3(Random.Range(col.bounds.center.x - 4f, col.bounds.center.x - col.bounds.extents.x )
                , Random.Range(col.bounds.center.y - col.bounds.extents.y, col.bounds.center.y + col.bounds.extents.y ),0);
                break;
            //up
            case 2:
                targetRot = new Vector2(0,-1);
                area = new Vector3(Random.Range(col.bounds.center.x - 4f, col.bounds.center.x + 4f )
                , Random.Range(col.bounds.center.y + 3.5f, col.bounds.center.y + col.bounds.extents.y ),0);
                break;
            //down
            case 3:
                targetRot = new Vector2(0,1);
                area = new Vector3(Random.Range(col.bounds.center.x - 4f, col.bounds.center.x + 4f )
                , Random.Range(col.bounds.center.y - 3.5f, col.bounds.center.y - col.bounds.extents.y ),0);
                break;
        }
        return area;
    }

    public void updateScores(){
        scores += 100f;
        scoreText.text = scores.ToString();
    }

    public void updateEnemiesLeft(){
        Debug.Log(enemiesLeft);
        if(enemiesLeft > 0f){
            enemiesLeft -= 1f;
            enemiesText.text = enemiesLeft.ToString();
        }
    }

    public void respawnbb(){
        targetRot = new Vector2(0,1);
        Vector3 area = new Vector3(Random.Range(col.bounds.center.x - 4f, col.bounds.center.x - col.bounds.extents.x )
        , Random.Range(col.bounds.center.y - col.bounds.extents.y, col.bounds.center.y + col.bounds.extents.y ),0);
                
        GameObject.FindGameObjectWithTag("bb").transform.position = new Vector2(area.x, area.y);
    }
    //
}
