using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int hearts = 3;
    public bool _alive = true;

    void Start(){

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
        
        Managers.Audio.AlienDied();
        yield return new WaitForSeconds(1.5f);


        Destroy(this.gameObject);
    }
}
