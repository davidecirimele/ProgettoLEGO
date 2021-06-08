using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SentinelAI : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] private int waypointPosition;
    NavMeshAgent navMeshAgent;
    public int range = 1;

    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;

    public float speed = 2.0f;

    Rigidbody rb;

    private bool changeDest;

    private bool detected;

    private GameObject player;

    public float wanderRadius;

    private GameObject startPoint;

    private bool firstStep;

    void Start(){
        rb = GetComponent<Rigidbody>();
         
        changeDest = true;
        firstStep = true;
    }

    void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_DETECTED, Follow);
        Messenger.AddListener(GameEvent.PLAYER_LOST, Unfollow);
        wayPoints = new List<Transform>();
        startPoint = GameObject.Find(RandomStart());
        navMeshAgent = GetComponent<NavMeshAgent>();
        Move();
    }

    void Update()
    {
        if(GetComponent<ReactiveTarget>().isAlive()){  

            if (verifyInRange(range, startPoint.transform.position))
                firstStep = false;

            if(detected){
                InvokeRepeating("Shoot", 0, 1);
                transform.LookAt(player.transform.position + new Vector3(0,1,0));
            }

            else if(!detected)                
                CancelInvoke("Shoot");

            Move();
        }
        else
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            detected = true;
            Messenger.Broadcast(GameEvent.PLAYER_DETECTED);
            if(player==null)
                player = other.gameObject;
        }

        else if(other.tag != "Player" || other.tag != "Alien"){
            changeDest = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            detected = false;
        }
    }

    bool verifyInRange(int range, Vector3 pos)
    {
        if (transform.position.x < pos.x + 1 && transform.position.x > pos.x - 1)
            if (transform.position.z < pos.z + 1 && transform.position.z > pos.z - 1)
            {
                return true;
            }
        return false;
    }

    void Move()
    {
        if(detected){
            if(firstStep)
                firstStep = false;
            navMeshAgent.SetDestination(player.transform.position);
        }

        if(firstStep){
            navMeshAgent.SetDestination(startPoint.transform.position);
            }

        else if(!firstStep && !detected && changeDest){
            Vector3 newPos = RandomNavSphere(startPoint.transform.position, wanderRadius, -1);
            navMeshAgent.SetDestination(newPos);
            changeDest = false;
        }
        
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

    void Follow(){
        if(player == null)
            player = GameObject.FindWithTag("Player");
        detected = true;
    }

    void Unfollow(){
        detected = false;
    }

    void Shoot(){
        Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.75f, out hit)){

                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.GetComponent<PlayerCharacter>()) {
                    
                    _laser = Instantiate(laserPrefab) as GameObject;
                    _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _laser.transform.rotation = transform.rotation;
                    
                }
                
            }
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.PLAYER_DETECTED, Follow); 
        Messenger.RemoveListener(GameEvent.PLAYER_LOST, Unfollow); 
    }

     public string RandomStart(){

        System.Random r = new System.Random();
        int n = r.Next(1,2);

        switch(n){
            case 1:
                return "first";
            case 2:
                return "second";
        }
        return "";
    }
}