using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    void Update()
    {
            transform.rotation = Quaternion.Euler(cam.eulerAngles);
    }
}
