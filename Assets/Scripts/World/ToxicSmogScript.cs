using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicSmogScript : MonoBehaviour
{

    private bool detected;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        detected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!detected)
            CancelInvoke("HurtPlayer");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            if(player==null)
                player = other.gameObject; 
            detected = true;
            InvokeRepeating("HurtPlayer", 0, 2);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            detected = false;
        }
    }

    private void HurtPlayer(){
        player.GetComponent<PlayerCharacter>().Hurt(1);
    }
}
