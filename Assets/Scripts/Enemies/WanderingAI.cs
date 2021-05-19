using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Control Script/AlienScript")]
public class WanderingAI : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] private int waypointPosition;
    NavMeshAgent navMeshAgent;
    public int range = 1;

    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;

    void Awake()
    {
        wayPoints = new List<Transform>();
        foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("Waypoint")) { wayPoints.Add(tmp.transform); }
        _alive = true;
        navMeshAgent = GetComponent<NavMeshAgent>();
        //Move();
    }

    void Update()
    {
        if(_alive){  
            if (verifyInRange(range, wayPoints[waypointPosition].position))
                Move();
       
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.75f, out hit)){
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>()) {
                
                    if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                    }
                }

                else if(hit.distance < obstacleRange){
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
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
        waypointPosition = Random.Range(0, wayPoints.Count);
        navMeshAgent.SetDestination(wayPoints[waypointPosition].position);
    }
}