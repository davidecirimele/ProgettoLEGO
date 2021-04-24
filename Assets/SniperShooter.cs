using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCamera : MonoBehaviour
{

	private Camera _camera;
    public Texture cursorTexture;
    public int cursorSize;

    public GameObject sniperScope;
    private bool sniperMode = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        
        (sniperScope.GetComponent<Renderer>()).enabled = false;

        Cursor.lockState = CursorLockMode.Locked; // lock mouse on the center 
        Cursor.visible = false; // hide mouse cursor
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown (1) && !sniperMode){
            _camera.fieldOfView = 10f;
            PlayerCharacter sensVert = GetComponent<PlayerCharacter>();
            sensVert.sensitivityVert = 1f;

            (sniperScope.GetComponent<Renderer>()).enabled = true;

            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            PlayerCharacter sensHor = player.GetComponent<PlayerCharacter>();
            sensHor.sensitivityHor = 1f;
            sniperMode = true;
        }

        if(Input.GetMouseButtonUp (1) && sniperMode){
            _camera.fieldOfView = 60f;
            PlayerCharacter sensVert = GetComponent<PlayerCharacter>();
            sensVert.sensitivityVert = 9.0f;

            (sniperScope.GetComponent<Renderer>()).enabled = false;

            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();
            PlayerCharacter sensHor = player.GetComponent<PlayerCharacter>();
            sensHor.sensitivityHor = 9.0f;
            sniperMode = false;
        }
    }
}
