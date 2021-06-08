using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrigger : MonoBehaviour
{
    bool detected;
    [SerializeField] private GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dog!=null){
            if(dog.GetComponent<ReactiveTarget>().isAlive())
                if(detected){
                    dog.GetComponent<AlienDogAI>().Follow();
                    //Messenger.Broadcast(GameEvent.DETECTED_DOG);
                }
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && dog.GetComponent<ReactiveTarget>().isAlive()){
            detected = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player" && dog.GetComponent<ReactiveTarget>().isAlive()){
            detected = false;
            dog.GetComponent<AlienDogAI>().Unfollow();
            //Messenger.Broadcast(GameEvent.LOST_DOG);
        }
    }

}