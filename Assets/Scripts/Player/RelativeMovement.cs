using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour {
    
    [SerializeField] private Transform target;
    [SerializeField] private Animator animator;

    public float rotSpeed = 15.0f;

    public float moveSpeed = 6.0f;
    private CharacterController _charController;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    private float _vertSpeed;

    private ControllerColliderHit _contact;

    //Sound
    private AudioSource _soundSource;
    [SerializeField] private AudioClip footStepSound;
    [SerializeField] private AudioClip jumpSound;
    private float _footStepSoundLength;
    private bool _step;
    private bool jumping;


    // Start is called before the first frame update
    void Start()
    {
        _vertSpeed = minFall;
        _charController = GetComponent<CharacterController>();
        _soundSource = GetComponent<AudioSource>();
        _step = true;
        _footStepSoundLength = 0.20f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        if(_charController.velocity.magnitude > 1f && _step){
            _soundSource.PlayOneShot(footStepSound);
            StartCoroutine(WaitForFootSteps(_footStepSoundLength));
        }

        if(horInput != 0 || vertInput != 0){
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            animator.SetFloat("isMoving", Mathf.Abs(vertInput) + Mathf.Abs(horInput));
            //movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }

        bool hitGround = false;
        RaycastHit hit;
        if(_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)){
            float check = (_charController.height + _charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
            
        }

        if(hitGround){
            if(Input.GetButtonDown("Jump")){
                jumping = true;
                _soundSource.PlayOneShot(jumpSound);
                _vertSpeed = jumpSpeed;
            } else {
                _vertSpeed = minFall;
            }
        } else {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if(_vertSpeed < terminalVelocity){
                _vertSpeed = terminalVelocity;
            }

            if(_charController.isGrounded){
                if(Vector3.Dot(movement, _contact.normal) < 0){
                    movement = _contact.normal * moveSpeed;
                    
                } else {
                    movement += _contact.normal * moveSpeed;
                    
                }
            }
        }

        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        _contact = hit;
    }

    IEnumerator WaitForFootSteps(float stepsLength){
        _step = false;
        yield return new WaitForSeconds(stepsLength);
        _step = true;
    }
}
