using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject(){
      
        Vector3 pos = new Vector3(Random.Range(-45f, 20f), 0, Random.Range(-20f, 20f)) + transform.position;
        Instantiate(spawnee, pos, transform.rotation);
        if(stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }
}
