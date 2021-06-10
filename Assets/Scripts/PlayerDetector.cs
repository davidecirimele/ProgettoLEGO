using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private GameObject Sniper1;
    [SerializeField] private GameObject Sniper2;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other) {
         
        if(other.tag == "Player"){
            Messenger.Broadcast(GameEvent.PLAYER_LOST);
            if(Sniper1 != null)
            Sniper1.GetComponent<SniperAI>().activeScript();
            if(Sniper2 != null)
            Sniper2.GetComponent<SniperAI>().activeScript();
        }
    }

}