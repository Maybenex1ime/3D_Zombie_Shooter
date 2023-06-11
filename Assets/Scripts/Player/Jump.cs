using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Player
{
    public class Jump : MonoBehaviour
    {
        private List<Utility.Utility.WrapperOffMeshLinkData> _links;
        [SerializeField] private NavMeshDataObject _data;
        [SerializeField] private InputActionReference _jumpButton;
        private NavMeshAgent _navMeshAgent;
        private PlayerInput _playerInput;
        private void Awake()
        {
            _links = _data._datas;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            // if (_jumpButton.action.)
            // {
            //     Debug.Log("Space Pressed");
            //     foreach (Utility.Utility.WrapperOffMeshLinkData link in _links)
            //     {
            //         if (Vector3.Distance(link.endPos, this.transform.position) < link.radius)
            //         {
            //             _navMeshAgent.SetDestination(link.startPos);
            //         }
            //     }
            // }
        }

        public void TraverseLink()
        {
            Debug.Log("Space Pressed");
            foreach (Utility.Utility.WrapperOffMeshLinkData link in _links)
            {
                if (Vector3.Distance(link.endPos, this.transform.position) < link.radius)
                {
                    _navMeshAgent.SetDestination(link.startPos);
                }
            }
        }
    }
}