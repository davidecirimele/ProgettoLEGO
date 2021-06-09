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

    private void OnCollisionEnter(Collision other) {
        PlayerCharacter player = other.gameObject.GetComponent<PlayerCharacter>();

        if(player != null){
           player.Hurt(1);
        }

        if(_soundSource != null && impactSound!=null)
            _soundSource.PlayOneShot(impactSound);
    }
}
