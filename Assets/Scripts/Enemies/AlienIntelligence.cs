using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienIntelligence : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;

    // Start is called before the first frame update
    void Start()
    {
      _alive = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(_alive){
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(ray, 0.75f, out hit)){

                if(hit.distance <= obstacleRange){
                    GameObject hitObject = hit.transform.gameObject;
                    if(hitObject.GetComponent<PlayerCharacter>()) {
                
                        if(_laser == null){
                            _laser = Instantiate(laserPrefab) as GameObject;
                            _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            _laser.transform.rotation = transform.rotation;
                        }
                    
                    float angle = hitObject.transform.position.x;
                    transform.Rotate(0, angle, 0);
                    }

                else{
                    float angle = Random.Range(90, 199);
                    transform.Rotate(0, angle, 0);
                }
                }   
            }
       
        }
    }

    public void setAlive(bool alive){
        _alive = alive;
    }
}
