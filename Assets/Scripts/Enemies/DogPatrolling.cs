using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPatrolling : MonoBehaviour
{
    public Transform[] points;
    int current;
    bool detected;
    public float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        detected=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!detected){
            if(transform.position != points[current].position + new Vector3(0,0,-2)){
                transform.LookAt(points[current].transform.position);
                transform.position = Vector3.MoveTowards(transform.position, points[current].position + new Vector3(0,0,-2), speed*Time.deltaTime);
            } else {
                current = (current+1) % points.Length;
            }
        }
    }

    public void GoToSleep(){
        detected=false;
    }

    public void Attack(){
        detected=true;
    }
    
}
