using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public float spawnTime;
    public float spawnDelay;
    public int interval = 10;
    public int numberAliens = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject(){
        Instantiate(spawnee, transform.position, transform.rotation, transform.parent);
        numberAliens--;
        if(numberAliens == 0){
            CancelInvoke("SpawnObject");
        }
    }
}

