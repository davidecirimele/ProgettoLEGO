using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMovement : MonoBehaviour
{
    [SerializeField] bool isHided;
    [SerializeField] RectTransform Inventory;
    public float speed = 1f;

    void Start()
    {
        Inventory = GetComponent<RectTransform>();
        isHided = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isHided)
                isHided = false;
            else
                isHided = true;
        }
        if (isHided && Inventory.anchoredPosition.y > 40)
            transform.position -= new Vector3(0f, speed, 0f);
        else if (!isHided && Inventory.anchoredPosition.y < 190)
            Inventory.position += new Vector3(0f, speed, 0f);
    
        if(isHided == false){
            
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                Managers.Spawn.SetSpawnee(0);
                Managers.Inventory.changeObject("alienTransporter");
            }

            if(Input.GetKeyDown(KeyCode.Alpha2)){
                Managers.Spawn.SetSpawnee(1);
                Managers.Inventory.changeObject("bridge");
            }

            if(Input.GetKeyDown(KeyCode.Alpha3)){
                Managers.Spawn.SetSpawnee(2);
                Managers.Inventory.changeObject("ladder");
            }
        }
    }
}
