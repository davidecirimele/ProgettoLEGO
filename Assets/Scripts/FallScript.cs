using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
   void OnTriggerEnter(Collider other) {
      PlayerCharacter player = other.GetComponent<PlayerCharacter>();
       
      if(player != null){
         player.Hurt(1);
         player.transform.position += new Vector3(0, 20, 0);
      }
   }
}
