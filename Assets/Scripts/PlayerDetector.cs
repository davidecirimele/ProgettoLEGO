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
            Sniper1.GetComponent<SniperAI>().activeScript();
            Sniper2.GetComponent<SniperAI>().activeScript();
        }
    }

}