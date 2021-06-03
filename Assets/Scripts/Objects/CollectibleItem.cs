using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>())
        {
            Debug.Log("Item collected: " + itemName);
            Managers.Inventory.AddItem(itemName);
            Messenger.Broadcast(GameEvent.COLLECTED);
            Destroy(this.gameObject);
        }
    }
}
