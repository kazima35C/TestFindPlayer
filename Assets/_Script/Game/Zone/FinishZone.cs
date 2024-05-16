using System.Collections;
using System.Collections.Generic;
using _Game.Manager;
using UnityEngine;

namespace _Game._Zone
{
    //Controls the behavior of the finish zone.
    public class FinishZone : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        void OnTriggerEnter(Collider other)
        {
            if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                Debug.Log("Trigger Player");
                GameManager.Instance.FinishStage();
            }

        }
    }
}
