using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerManager : MonoBehaviour, IGameManager
{
   [SerializeField] private List<GameObject> spawnableObjects;
    [SerializeField] private List<GameObject> spawnableObjectsMockup;
    [SerializeField] private GameObject spawnee;
    [SerializeField] private GameObject spawneeMockup;
    [SerializeField] private GameObject objectMesh;
    [SerializeField] private Transform player;

    private bool isPlacing = false;
    public ManagerStatus status { get; private set; }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetMouseButtonDown(1) && Managers.Inventory.checkForCreation(getObjectName())) {
                isPlacing = true;
                SpawnMockupObjectAtPositon(new Vector3(0f, 0f, 0f));
            }

            if (isPlacing) {
                Vector3 mouseScreenPosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    objectMesh.transform.position = hitInfo.point + objectMesh.GetComponent<Offset>().getOffset();
                    objectMesh.transform.rotation = new Quaternion(0f, player.transform.rotation.y, 0f, player.transform.rotation.w);
                }

                if (Input.GetMouseButtonUp(1))
                {
                    Destroy(objectMesh);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo2))
                    {
                        SpawnObjectAtPositon(hitInfo2.point);
                    }
                }
            }
        }
    }
    
    private void SpawnMockupObjectAtPositon(Vector3 spawnPosition)
    {
        objectMesh = Instantiate(spawneeMockup, spawnPosition + spawnee.GetComponent<Offset>().getOffset(), new Quaternion(0f, player.transform.rotation.y, 0f, player.transform.rotation.w));
    }

    private void SpawnObjectAtPositon(Vector3 spawnPosition){
        Managers.Audio.CreateObject();
        GameObject obj = Instantiate(spawnee, spawnPosition + spawnee.GetComponent<Offset>().getOffset(), new Quaternion(0f, player.transform.rotation.y, 0f, player.transform.rotation.w));
        isPlacing = false;
    }

    public void Startup()
    {
        Debug.Log("Spawner Objects manager starting...");
        spawnableObjects = new List<GameObject>();
        foreach(Object obj in Resources.LoadAll("Spawnable", typeof(GameObject)))
            spawnableObjects.Add(Instantiate(obj) as GameObject);
        
        foreach(Object obj in Resources.LoadAll("SpawnableMockup", typeof(GameObject)))
            spawnableObjectsMockup.Add(Instantiate(obj) as GameObject);
        if (spawnableObjects.Count != 0)
        {
            spawnee = spawnableObjects[2];
            spawneeMockup = spawnableObjectsMockup[2];
        }
        status = ManagerStatus.Started;
    }

    public string getObjectName()
    {
        return spawnee.name;
    }

    public GameObject GetGameObject()
    {
        return spawnee;
    }

    public void SetSpawnee(int chObj){
        if (spawnableObjects.Count != 0)
        {
            Managers.Audio.ChangeObjectSpawn();
            spawnee = spawnableObjects[chObj];
            spawneeMockup = spawnableObjectsMockup[chObj];
        }
    }
}
