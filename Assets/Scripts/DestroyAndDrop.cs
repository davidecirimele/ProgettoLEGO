using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndDrop : MonoBehaviour
{
	int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        damage=0;
    }

    // Update is called once per frame
    void Update()
    {
    	
        if(damage==4){
        	Debug.Log("CIAO");
        	//Destroy(this.gameObject);
        }
    }

    public void Damage(){
    	damage+=1;
    }
}
