using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed = 0;

    [SerializeField] private Transform tank;
    [SerializeField] private Transform wheel1;
    [SerializeField] private Transform wheel2;
    [SerializeField] private Transform wheel3;
    [SerializeField] private Transform wheel4;

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
            Change();
        }
    }

    public void Move(){
        speed = 15;
    }

    public void Stop(){
        speed = 0;
    }

    private void Change(){
        tank.LookAt(points[current].position + new Vector3(0,6,0));
        wheel1.LookAt(points[current].position);
        wheel2.LookAt(points[current].position);
        wheel3.LookAt(points[current].position);
        wheel4.LookAt(points[current].position);
    }
}
