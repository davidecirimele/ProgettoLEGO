using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   //public Transform spawnPos;
   public GameObject spawnee;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
           
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                GameObject hitObject = hit.transform.gameObject;
                if(hitObject != null){
                   Instantiate(spawnee, hitObject.transform);
                    
                }
            }
        }
            
        
    }
}
