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
            transform.Rotate(speed, 0, 0,Space.Self);
        }
        
    }

    public void setStart(){
        start = true;
    }

    public void setStop(){
        start = false;
    }

    private void OnCollisionEnter(Collision other) {
        PlayerCharacter player = other.gameObject.GetComponent<PlayerCharacter>();
       
        if(player != null){
           player.Hurt(1);
        }
    }
}
