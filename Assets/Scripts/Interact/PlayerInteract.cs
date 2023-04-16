using System;
using UnityEngine;

namespace Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        public Transform _orientation;
        [SerializeField] private float _distance = 3f;
        [SerializeField] private LayerMask _mask;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            Ray _ray = new Ray(_orientation.position, _orientation.forward);
            Debug.DrawRay(_ray.origin, _ray.direction * _distance);
            RaycastHit hitInfo;
            if (Physics.Raycast(_ray, out hitInfo, _distance, _mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                }
            }
        }
    }
}