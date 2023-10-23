using UnityEngine;

namespace Dumb_Shit
{
   public class FollowPlayer : MonoBehaviour
   {
      [SerializeField] private Transform _target;
    
      private void Update()
      {
         // Calculate the direction from this object to the player
         Vector3 direction = _target.position - transform.position;

         // Calculate the rotation to face the player
         Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

         // Apply the rotation to this object
         transform.rotation = rotation;
      }
   }
}
