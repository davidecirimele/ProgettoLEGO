using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{

    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    private float _rotY;
    private float _rotX;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;
        _offset = target.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void LateUpdate()
    {

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        //if(horInput != 0 || verInput != 0){
        //    _rotY += horInput * rotSpeed;
        //    _rotX -= verInput * rotSpeed;
        //} else {
            _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            _rotX -= Input.GetAxis("Mouse Y") * rotSpeed * 3;
        //}

        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        
        transform.LookAt(target.position);
    }
}
