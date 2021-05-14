using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    private void Awake()
    {
        rotationSpeed = 90f;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
    }
}
