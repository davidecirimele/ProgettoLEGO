using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienTransporterScript : MonoBehaviour
{
    private bool fly = false;
    //private PlayerCharacter player;

    void Update(){
        if(fly == true){
            Debug.Log("Vola");
            
            transform.parent.Translate(0, 3f * Time.deltaTime, 8f * Time.deltaTime);
            //player.transform.Translate(0, 3 * Time.deltaTime, 3 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        

        if(player != null){
           fly = true;
        }

    }
}
