using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAI : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;
    Rigidbody rb;
    private bool _detected;
    private bool _active;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         _active = false;
         _detected = false;
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_LOST, Unfollow); 
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ReactiveTarget>().isAlive()){  

            if(_active){ 
                transform.LookAt(player.transform.position + new Vector3(0,1.6f,0));
            }

            if(_detected){
                Shoot();
            }
        }
        else
            Debug.Log("Sono Morto");
    }


    void Shoot(){
        if(_laser == null){
            _laser = Instantiate(laserPrefab) as GameObject;
            _laser.transform.position = transform.TransformPoint(Vector3.forward);
            _laser.transform.rotation = transform.rotation;
        }     
    } 
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall"){  
            _detected = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Wall"){  
            _detected = true;
        }
    }

    void Unfollow(){
        _detected = false;
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.PLAYER_LOST, Unfollow); 
    }

   public void activeScript(){
       _active = true;

       _detected = true;

       if(player==null)
            player = GameObject.Find("legoCharacter");
   }

}
