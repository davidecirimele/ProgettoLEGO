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
        else if (!isHided && Inventory.anchoredPosition.y < 150)
            Inventory.position += new Vector3(0f, speed, 0f);
    }
}
