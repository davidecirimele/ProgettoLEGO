using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{
    public float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {
    	
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(0, 0, speed * Time.deltaTime);  
    }

    void OnTriggerEnter(Collider other) {
        DestroyAndDrop destroyable = other.GetComponent<DestroyAndDrop>();
        Debug.Log("Hello");
        destroyable.Damage();
        
        Destroy(this.gameObject);
    }
}
