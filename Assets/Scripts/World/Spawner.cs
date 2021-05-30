using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject spawnee;
   [SerializeField] private Vector3 offsetSpawnPosition;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject()){
           
           Vector3 mouseScreenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo)){
               SpawnObjectAtPositon(hitInfo.point);
            }
        }
    }

    private void SpawnObjectAtPositon(Vector3 spawnPosition){
        GameObject obj = Instantiate(spawnee, spawnPosition + offsetSpawnPosition, Quaternion.identity);
    }
}
