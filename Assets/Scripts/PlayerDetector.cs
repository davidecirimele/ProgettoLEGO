using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    bool detected;
    [SerializeField] private GameObject Sniper1;
    [SerializeField] private GameObject Sniper2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(detected){
            Sniper1.GetComponent<SniperAI>().Look();
            Sniper2.GetComponent<SniperAI>().Look();
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Messenger.Broadcast(GameEvent.PLAYER_LOST);
            detected = true;
        }
    }

}