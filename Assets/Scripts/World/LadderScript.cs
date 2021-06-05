using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Transform chController;
	bool inside = false;
	public float speedUpDown = 3f;
	public RelativeMovement relativeMovement;

void Start()
{
	relativeMovement = GetComponent<RelativeMovement>();
	inside = false;
}

void OnTriggerEnter(Collider col)
{
	if(col.gameObject.tag == "Ladder")
	{
        Debug.Log("Entro");
		relativeMovement.enabled = false;
		inside = !inside;
	}
}

void OnTriggerExit(Collider col)
{
	if(col.gameObject.tag == "Ladder")
	{
         Debug.Log("Esco");
		relativeMovement.enabled = true;
		inside = !inside;
	}
}
		
void Update()
{
	if(inside == true && Input.GetKey("w"))
	{
			chController.transform.position += Vector3.up / speedUpDown;
	}
	
	if(inside == true && Input.GetKey("s"))
	{
			chController.transform.position += Vector3.down / speedUpDown;
	}
}

}
