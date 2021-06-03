using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlienBoss : MonoBehaviour
{

    [SerializeField] private GameObject laserPrefab;
    private GameObject _laser;
    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting == true){
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.75f, out hit)){

                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.GetComponent<PlayerCharacter>()) {
                    if(_laser == null){
                        _laser = Instantiate(laserPrefab) as GameObject;
                        _laser.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _laser.transform.rotation = transform.rotation;
                    }
                }
            }
        }
    }

    public void Shoot(){
        shooting = true;
    }
}
