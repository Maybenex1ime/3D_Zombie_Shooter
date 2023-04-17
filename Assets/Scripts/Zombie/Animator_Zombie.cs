using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class Animator_Zombie : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            _animator.SetFloat("speed", _navMeshAgent.velocity.magnitude);
        }
        
    }
}