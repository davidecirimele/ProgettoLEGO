using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int hearts = 3;

   public void ReactToHit(){
        
        hearts--;

        WanderingAI behaviour = GetComponent<WanderingAI>();
        

        if(hearts==0){

        if(behaviour != null){
            behaviour.setAlive(false);
        }

        StartCoroutine(Die());
        }
    }

    private IEnumerator Die(){
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}