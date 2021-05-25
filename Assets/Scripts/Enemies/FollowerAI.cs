using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Control Script/AlienScript")]
public class FollowerAI : MonoBehaviour
{

    [SerializeField] List<Transform> wayPoints;
    [SerializeField] private int waypointPosition;
    NavMeshAgent navMeshAgent;
    public int range = 1;

    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;

    public float speed = 3.0f;
    public float obstacleRange = 1.0f;

    Rigidbody rb;

    private bool _alive;

    private bool followPlayer;

    private int stopCount = 0;

    private GameObject player;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        wayPoints = new List<Transform>();
        foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Waypoint")) { wayPoints.Add(tmp.transform); }
        _alive = true;
        followPlayer = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        Move();
    }

    void Update()
    {
        if(_alive){  
            

            if(followPlayer){
                
                transform.LookAt(player.transform);

                Move();

                if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                    }
                        
            }

            else{
                if (verifyInRange(range, wayPoints[waypointPosition].position) && stopCount<150)
                    Move();
            }
       
            Ray ray1 = new Ray(transform.position, transform.forward);
        
            RaycastHit hit;
           if(Physics.SphereCast(ray1, 0.75f, out hit)){

                if(hit.distance <= obstacleRange){
                    GameObject hitObject = hit.transform.gameObject;
                    if(hitObject.GetComponent<PlayerCharacter>()) {
                    
                    player = hitObject;
                    if(!followPlayer)
                        followPlayer=true;
                    }
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
        if(!followPlayer){
            waypointPosition = Random.Range(0, wayPoints.Count);
            navMeshAgent.SetDestination(wayPoints[waypointPosition].position);
        }
        else{
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}