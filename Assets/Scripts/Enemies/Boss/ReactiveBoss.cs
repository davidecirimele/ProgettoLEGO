using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveBoss : MonoBehaviour
{
    public int hearts = 3;
    public bool alienDied;

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
        alienDied = true;
        //Messenger.Broadcast(GameEvent.BOSS_ALIEN_KILLED);
        this.transform.Rotate(-75, 0, 0);
        Debug.Log("I'm Dying");
        yield return new WaitForSeconds(1.5f);


        Destroy(this.gameObject);

        Win();
    }

    public void Win(){
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        Messenger.Broadcast(GameEvent.WIN);
    }
}
