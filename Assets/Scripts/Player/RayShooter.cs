using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ 
           
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null){
                    // hit target, so sphere not have to be show
                    target.ReactToHit(); //this function is in target Script
                }
                else{
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }

       
    }

    //COROUTINE CODE
    private IEnumerator SphereIndicator(Vector3 pos){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}

