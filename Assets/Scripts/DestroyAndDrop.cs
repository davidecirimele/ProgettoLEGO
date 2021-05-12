using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndDrop : MonoBehaviour
{
	int damage;
    
    public GameObject drop;

    public GameObject destroyable;
    
    // Start is called before the first frame update
    void Start()
    {
        destroyable = this.gameObject;
        
        damage=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(damage==4){
        	Destroy(this.gameObject);

            Instantiate(drop, destroyable.transform.position, drop.transform.rotation);
        }
    }

    public void Damage(){
    	damage+=1;
    }
}
