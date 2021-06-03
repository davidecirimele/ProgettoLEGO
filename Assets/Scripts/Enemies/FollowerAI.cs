using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Control Script/AlienScript")]
public class FollowerAI : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public int range = 1;

    public float wanderRadius;

    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;

    public float speed = 3.0f;
    public float obstacleRange = 1.0f;

    Rigidbody rb;

    private bool _alive;

    private bool followPlayer;

    private bool changeDest;

    private int stopCount = 0;

    private GameObject player;

    private GameObject startPoint;

    private bool firstStep;

    void Start(){
        rb = GetComponent<Rigidbody>();
        changeDest = true;
        firstStep = true;
        Move();
    }

    void Awake()
    {
        startPoint = GameObject.Find(RandomStart());
        _alive = true;
        followPlayer = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    

    void Update()
    {
        if(_alive){  

        if (verifyInRange(range, startPoint.transform.position))
            firstStep = false;
            
            if(followPlayer){
                
                transform.LookAt(player.transform.position + new Vector3(0,1,0));

                Move();

                if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                    }
                        
            }

            else if((!followPlayer && stopCount<300)||(stopCount>=300 && !followPlayer && changeDest==true))
                Move();
       
            Ray ray = new Ray(transform.position, transform.forward);
        
            RaycastHit hit;
           if(Physics.SphereCast(ray, 0.75f, out hit)){

                if(hit.distance <= obstacleRange){
                    GameObject hitObject = hit.transform.gameObject;
                    if(hitObject.GetComponent<PlayerCharacter>()) {
                    
                    player = hitObject;
                    
                    if(!followPlayer)
                        followPlayer=true;
                    }
                    else if(hitObject.tag!= "Player" && hitObject.tag != "Alien")
                        changeDest = true;
                }   
            }
       
        }
    }

    public void setAlive(bool alive){
        _alive = alive;
    }

    bool verifyInRange(int range, Vector3 pos)
    {
            stopCount++;
            if (transform.position.x < pos.x + 1 && transform.position.x > pos.x - 1)
                if (transform.position.z < pos.z + 1 && transform.position.z > pos.z - 1)
                {
                    return true;
                }
            return false;
        
    }

    void Move()
    {
       if(firstStep){
            navMeshAgent.SetDestination(startPoint.transform.position);
            }
        else if(!firstStep && !followPlayer && changeDest){
            Vector3 newPos = RandomNavSphere(startPoint.transform.position, wanderRadius, -1);
            navMeshAgent.SetDestination(newPos);
            changeDest = false;
        }
        else if(!firstStep && followPlayer){
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }

    public string RandomStart(){

        System.Random r = new System.Random();
        int n = r.Next(0,3);

        switch(n){
            case 0:
                return "second";
            case 1:
                return "first";
            case 2:
                return "second";
            case 3:
                return "first";

        }
        return "";
    }
}