using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position){
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*Time.deltaTime);
        } else {
            current = (current+1) % points.Length;
        }
    }

    public void Move(){
        speed = 15;
    }

    public void Stop(){
        speed = 0;
    }
}
