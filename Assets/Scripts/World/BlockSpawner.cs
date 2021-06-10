using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public float spawnTime;
    public float spawnDelay;
    public int interval = 10;
    public int numberAliens = 10;

    private AudioSource _soundSource;
    [SerializeField] private AudioClip impactSound;

    // Start is called before the first frame update
    void Start()
    {
        _soundSource = GetComponent<AudioSource>();  
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject(){
        Instantiate(spawnee, transform.position + new Vector3(Random.Range(-15,30),0,Random.Range(-30,30)), transform.rotation, transform.parent);
        numberAliens--;
        
    }

    public void ImpactSound(){
        if(_soundSource != null && impactSound!=null)
            _soundSource.PlayOneShot(impactSound);
    }
}
