using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
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
        InvokeRepeating("SpawnObject1", spawnTime, spawnDelay);
        InvokeRepeating("SpawnObject2", spawnTime, spawnDelay);
    }

    void Update(){
        if(counter==100)
            stopSpawning=true;
    }

    public void SpawnObject1(){
        Instantiate(spawnee1, transform.position, transform.rotation);
        if(stopSpawning){
            CancelInvoke("SpawnObject1");
        }
    }

    public void SpawnObject2(){
        Instantiate(spawnee2, transform.position, transform.rotation);
        if(stopSpawning){
            CancelInvoke("SpawnObject2");
        }
    }
}