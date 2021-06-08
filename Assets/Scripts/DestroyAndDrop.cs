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

            Debug.Log(transform.position);
            Instantiate(drop, new Vector3(transform.position.x, 0f, transform.position.z) + new Vector3(0,1f,0), drop.transform.rotation);
        }
    }

    public void Damage(){
    	damage+=1;
    }
}
