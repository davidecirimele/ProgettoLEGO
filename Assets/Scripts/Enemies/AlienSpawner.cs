using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject spawnee1;
    public GameObject spawnee2;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSentinel", spawnTime, spawnDelay);
        InvokeRepeating("SpawnFollower", spawnTime, spawnDelay);
    }

    void Update(){
        if(counter==10)
            stopSpawning=true;
    }

    public void SpawnSentinel(){
        Instantiate(spawnee1, transform.position, transform.rotation);
        counter+=1;
        if(stopSpawning){
            CancelInvoke("SpawnSentinel");
        }
    }

    public void SpawnFollower(){
        Instantiate(spawnee2, transform.position, transform.rotation);
        counter+=1;
        if(stopSpawning){
            CancelInvoke("SpawnFollower");
        }
    }
}

