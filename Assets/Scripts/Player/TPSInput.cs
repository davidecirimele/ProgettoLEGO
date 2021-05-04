using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSInput : MonoBehaviour
{
    [SerializeField] private CharacterController _charController;
    [SerializeField] public Transform cam;


    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float gorundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 movement;
    bool isGrounded;

    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

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

        Vector3 direction = new Vector3(deltaX, 0f, deltaZ).normalized;

        if(direction.magnitude >= 0.1f){
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _charController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        //Vector3 move = transform.right * deltaX + transform.forward * deltaZ;
	    //movement = Vector3.ClampMagnitude(movement, speed);

        

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            movement.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        movement.y += gravity * Time.deltaTime;
        _charController.Move(movement * Time.deltaTime);

    }
}
