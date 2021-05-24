using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed = 0;
    
    void Awake() {
        Messenger.AddListener(GameEvent.DETECTED, Move);
        Messenger.AddListener(GameEvent.BOSS_ALIEN_KILLED, Stop);    
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.DETECTED, Move);
        Messenger.RemoveListener(GameEvent.BOSS_ALIEN_KILLED, Stop); 
    }

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position){
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*Time.deltaTime);
        } else {
            current = (current+1) % points.Length;
        }
    }

    private void Move(){
        speed = 15;
    }

    private void Stop(){
        speed = 0;
    }
}
