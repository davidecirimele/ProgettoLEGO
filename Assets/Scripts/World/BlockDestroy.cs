using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{

    public float lifeTime = 10f;
    
    [SerializeField] private GameObject spawner;

    void Start() {
        spawner = GameObject.Find("BlockSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0){
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0){
                Destruction();
            }
        }
    }

    void Destruction(){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        PlayerCharacter player = other.gameObject.GetComponent<PlayerCharacter>();
        

        if(player != null){
           player.Hurt(1);
        }

        spawner.GetComponent<BlockSpawner>().ImpactSound();
    }
}
