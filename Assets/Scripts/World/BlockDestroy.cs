using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{

    public float lifeTime = 10f;
    
    private AudioSource _soundSource;
    [SerializeField] private AudioClip impactSound;

    void Start() {
        _soundSource = GetComponent<AudioSource>();    
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

    void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
       
        if(player != null){
           player.Hurt(1);
        } else {
            rb.AddForce(transform.up * 2);
        } 
        _soundSource.PlayOneShot(impactSound);
    }
}
