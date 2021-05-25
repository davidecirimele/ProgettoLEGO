using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update(){
        if(counter==40)
            stopSpawning=true;
    }

    public void SpawnObject(){
        Instantiate(spawnee, transform.position, transform.rotation);
        counter+=1;
        if(stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }
}

