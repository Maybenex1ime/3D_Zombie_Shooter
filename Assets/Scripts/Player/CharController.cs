using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System;

namespace DefaultNamespace
{
    public class CharController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerCamera _camera;
        
        public Transform _orientation;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _camera = GetComponentInChildren<PlayerCamera>();
        }

        private void Update()
        {
            #region Movement

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            transform.rotation = _orientation.transform.rotation;
            
            if (x != 0 || y != 0)
            {
                Vector3 moveDirection = _orientation.forward * y + _orientation.right * x;
                Vector3 movePosition = transform.position + moveDirection;
                _navMeshAgent.SetDestination(movePosition);
            }
            else
            {
                _navMeshAgent.SetDestination(transform.position);
            }

            #endregion

            #region Shooting

            if (Input.GetMouseButtonDown(0))
            {
                var from = _camera.transform.position;
                var direction = _camera.transform.forward; 
                BulletSpawner.instance.Show(from,direction);
            }

            #endregion
        }
    }
}