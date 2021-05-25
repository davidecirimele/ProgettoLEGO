using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    private void Awake()
    {
        rotationSpeed = 45;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
    }
}
