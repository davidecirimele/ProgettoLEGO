using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndDrop : MonoBehaviour
{
	int damage;
    
    public GameObject drop;

    // Start is called before the first frame update
    void Start()
    {   
        damage=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(damage==4){

            Managers.Audio.DestructionObject();
        	Destroy(this.gameObject);

            Instantiate(drop, this.gameObject.transform.position + new Vector3(0,1,0), drop.transform.rotation);
        }
    }

    public void Damage(){
    	damage+=1;
    }
}
