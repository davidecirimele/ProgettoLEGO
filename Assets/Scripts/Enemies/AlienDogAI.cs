using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDogAI : MonoBehaviour
{
    bool detected;
    GameObject player;
    [SerializeField] private GameObject dog;
    float speed = 11.0f;

    // Start is called before the first frame update
    void Start()
    {
        detected = false;
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.DETECTED_DOG, Follow);
        Messenger.AddListener(GameEvent.LOST_DOG, Unfollow);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ReactiveTarget>().isAlive()){
            if(detected){
                if(player==null)
                    player = GameObject.Find("legoCharacter");
                transform.LookAt(player.transform.position + new Vector3(0,1,0));
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    public void Follow(){
        if(dog!=null){
            detected=true;
            dog.GetComponent<DogPatrolling>().Attack();
        }
    }

    public void Unfollow(){
        if(dog!=null){
            detected=false;
            dog.GetComponent<DogPatrolling>().GoToSleep();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
       
            if(player != null){
                player.Hurt(1);
            }
        }
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.DETECTED_DOG, Follow); 
        Messenger.RemoveListener(GameEvent.LOST_DOG, Unfollow); 
    }
    
}
