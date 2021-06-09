using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    public GameObject Projectile;

    [SerializeField] private Transform target;
    [SerializeField] private int layerMask;
    public float time;
    private GameObject BossLife;

    private AudioSource _soundSource;
    [SerializeField] private AudioClip shotSound;

    void Start()
    {
        time = 0.05f;
        layerMask = ~ (1 << LayerMask.NameToLayer("Player"));
        //target = Camera.main.transform; // The Camera utilized by the character
        Cursor.lockState = CursorLockMode.Locked; // lock mouse on the center 
        //Cursor.visible = true;

        _soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(target.position, (transform.position - target.position) * 100, Color.red, 0.1f);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            _soundSource.PlayOneShot(shotSound);
            Ray ray = new Ray(target.position, (transform.position - target.position) * 100);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, layerMask)){
                SpawnBulletTrail(hit.point);
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (hit.transform.tag == "Destroyable")
                    hit.transform.GetComponent<DestroyAndDrop>().Damage();
                if (hit.transform.tag == "Boss")
                    if (hit.transform.GetComponent<BossLife>() != null)
                        hit.transform.GetComponent<BossLife>().Hitted(1);
                    else
                    {
                        BossLife = GameObject.Find("TankFree_Yel");
                        BossLife.GetComponent<BossLife>().Hitted(1);
                    }
                if (hit.transform.tag == "BossAlien")
                    hit.transform.GetComponent<ReactiveBoss>().ReactToHit();
                StartCoroutine(SpawnBulletTrail(hit.point));
                if (target != null)
                    target.ReactToHit(); //this function is in target Script
            }
        }

       
    }

    private IEnumerator SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject laser = GameObject.CreatePrimitive(PrimitiveType.Cube);
        laser.GetComponent<Renderer>().material.color = Color.red;
        laser.GetComponent<BoxCollider>().enabled = false;
        laser.transform.localScale = new Vector3(0.05f, 0.05f, 0.4f);
        laser.transform.position = transform.position;
        laser.transform.rotation = Quaternion.LookRotation(hitPoint - transform.position, Vector3.up);
        float i = 0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            laser.transform.position = Vector3.Lerp(transform.position, hitPoint, i);
            yield return null;
        }
        Destroy(laser.gameObject);
    }
}

