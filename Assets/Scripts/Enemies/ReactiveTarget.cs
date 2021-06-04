using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int hearts = 3;

    private AudioSource _soundSource;
    [SerializeField] private AudioClip diedSound;

    void Start(){
        _soundSource = GetComponent<AudioSource>();
    }
     
    public void ReactToHit(){
        
        hearts--;

        AlienIntelligence behaviour = GetComponent<AlienIntelligence>();
        

        if(hearts==0){

        if(behaviour != null){
            behaviour.setAlive(false);
        }

        StartCoroutine(Die());
        }
    }

    private IEnumerator Die(){
        this.transform.Rotate(-75, 0, 0);
        Debug.Log("I'm Dying");
        _soundSource.PlayOneShot(diedSound);
        yield return new WaitForSeconds(1.5f);


        Destroy(this.gameObject);
    }
}
