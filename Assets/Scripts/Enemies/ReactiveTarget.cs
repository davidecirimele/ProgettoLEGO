using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int hearts = 3;

    public bool _alive = true;

    private AudioSource _soundSource;
    [SerializeField] private AudioClip diedSound;

    void Start(){
        _soundSource = GetComponent<AudioSource>();
    }
     
    public void ReactToHit(){
        hearts--;
        
        if(hearts==0)
            StartCoroutine(Die());
    }

    public bool isAlive(){
        return _alive;
    }

    private IEnumerator Die(){
        _alive = false;

        this.transform.Rotate(-75, 0, 0);
        
        _soundSource.PlayOneShot(diedSound);
        yield return new WaitForSeconds(1.5f);


        Destroy(this.gameObject);
    }
}
