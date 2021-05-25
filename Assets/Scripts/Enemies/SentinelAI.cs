using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Control Script/AlienScript")]
public class SentinelAI : MonoBehaviour
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

    private bool sawPlayer;

    private GameObject player;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        wayPoints = new List<Transform>();
        foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Waypoint")) { wayPoints.Add(tmp.transform); }
        _alive = true;
        navMeshAgent = GetComponent<NavMeshAgent>();
        Move();
    }

    void Update()
    {
        if(_alive){  
            
            if (verifyInRange(range, wayPoints[waypointPosition].position))
                Move();

            if(sawPlayer){
                
                transform.LookAt(player.transform);

                Move();

                 if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                    }
                        
            }

           
                
            
       
            Ray ray = new Ray(transform.position, transform.forward);
           
            RaycastHit hit;
           if(Physics.SphereCast(ray, 0.75f, out hit)){

                if(hit.distance <= obstacleRange){
                    GameObject hitObject = hit.transform.gameObject;
                    if(hitObject.GetComponent<PlayerCharacter>()) {
                    
                    player = hitObject;
                    if(!sawPlayer)
                        sawPlayer=true;
                    }

                    else{
                        //followPlayer = false;
                        float angle = Random.Range(90, 199);
                        //transform.Rotate(0, angle, 0);
                    
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
        if (transform.position.x < pos.x + 1 && transform.position.x > pos.x - 1)
            if (transform.position.z < pos.z + 1 && transform.position.z > pos.z - 1)
            {
                return true;
            }
        return false;
    }

    void Move()
    {
        if(!sawPlayer){
            waypointPosition = Random.Range(0, wayPoints.Count);
            navMeshAgent.SetDestination(wayPoints[waypointPosition].position);
        }
        else{
            navMeshAgent.SetDestination(player.transform.position);
        }
    }
}