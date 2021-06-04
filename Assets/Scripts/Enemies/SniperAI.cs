using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;
    Rigidbody rb;
    private bool _alive;
    private bool detected;
    private GameObject player;
    public float obstacleRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         _alive = true;
    }

    void Awake()
    {
     Messenger.AddListener(GameEvent.PLAYER_DETECTED, Look);
     Messenger.AddListener(GameEvent.PLAYER_LOST, Unlook);
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.PLAYER_DETECTED, Look); 
        Messenger.RemoveListener(GameEvent.PLAYER_LOST, Unlook);
    }

    // Update is called once per frame
    void Update()
    {
        if(_alive){  

            if(detected){
                transform.LookAt(player.transform.position + new Vector3(0,1.6f,0));
                Shoot();
            }

        }
    }

    public void Look(){
        detected = true;

        if(player==null)
            player = GameObject.Find("legoCharacter");
    }

    public void Unlook(){
        detected = false;
    }

    void Shoot(){
         Ray ray = new Ray(transform.position, transform.forward);
        
            RaycastHit hit;
           if(Physics.SphereCast(ray, 0.75f, out hit)){

                if(hit.distance <= obstacleRange){
                    GameObject hitObject = hit.transform.gameObject;
                
                    if(!hitObject.GetComponent<PlayerCharacter>()) {
                    
                        if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                        }     
                    }
                }
        
            }
        }
}
