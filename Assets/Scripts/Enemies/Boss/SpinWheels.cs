using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWheels : MonoBehaviour
{
    public float speed = 3f;
    private bool start;

    void Start(){
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true){
            transform.Rotate(speed, 0, 0,Space.World);
        }
        
    }

    public void setStart(){
        start = true;
    }

    public void setStop(){
        start = false;
    }
}
