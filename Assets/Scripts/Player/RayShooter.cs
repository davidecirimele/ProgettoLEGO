using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~ (1 << LayerMask.NameToLayer("Player"));
        target = Camera.main.transform; // The Camera utilized by the character
        Cursor.lockState = CursorLockMode.Locked; // lock mouse on the center 
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = new Ray(target.position, (transform.position - target.position) * 10);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f, layerMask)){
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

