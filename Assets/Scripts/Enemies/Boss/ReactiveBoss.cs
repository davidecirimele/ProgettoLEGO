using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveBoss : MonoBehaviour
{
    public int hearts = 5;
    public bool alienDied;
    public bool _alive = true;

   public void ReactToHit(){
        hearts--;
        
        if(hearts==0){
            _alive = false;
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
