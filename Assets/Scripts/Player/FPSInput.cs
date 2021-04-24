using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]   // fa comparire nel menu del character controller lo script
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float gorundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 movement;
    bool isGrounded;

    private CharacterController _charController;

    void Start() {
        _charController = GetComponent<CharacterController>();
    }

    void Update() {

        isGrounded = Physics.CheckSphere(groundCheck.position, gorundDistance, groundMask);

         if(isGrounded && movement.y < 0){
            movement.y = -2f;
        }

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * deltaX + transform.forward * deltaZ;
	    //movement = Vector3.ClampMagnitude(movement, speed);

        _charController.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        movement.y += gravity * Time.deltaTime;
        _charController.Move(movement * Time.deltaTime);

    }
}