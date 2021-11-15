using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public class Calculations : MonoBehaviour
    {

        public static float GetAnimLenght(Animation animation)
        {
            return animation.clip.length;
        }

        public static float DistanceToObject(Transform target, Transform origin)
        {
            float distance = Vector3.Distance(target.position, origin.position);
            return distance;
        }

        public static bool IsObjectInView(Transform target, Transform origin)
        {
            Vector3 lookDir = (target.position - origin.position).normalized;
            float dot = Vector3.Dot(lookDir, origin.forward);

            if (dot >= .7 || dot <= -.3)
            {
                //Checks if target is within set FOV
                if (Physics.Raycast(origin.position, lookDir, out RaycastHit hit))
                {
                    //If player is in FOV, within distance and in view, return true
                    return (hit.collider.tag == target.tag);
                }
            }
            return false;
        }


        public static Transform ClosestObject(List<Transform> targets, Transform origin)
        {
            float closestDistance = Mathf.Infinity;

            foreach(Transform t in targets)
            {
                float distance = Vector3.Distance(origin.position, t.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    return t;
                }
            }
            return null;
        }
    }
}
