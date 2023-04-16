using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class Animator_Zombie : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private AnimationEventHandler _eventHandler;

        public event Action OnExit;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _eventHandler = GetComponent<AnimationEventHandler>();
        }

        void Update()
        {
            _animator.SetFloat("speed", _navMeshAgent.velocity.magnitude);
        }

        public void Enter()
        {
            OnExit?.Invoke();
        }

        private void Exit()
        {
            
        }
        
        private void OnEnable()
        {
            _eventHandler.OnFinish += Exit;
        }

        private void OnDisable()
        {
            _eventHandler.OnFinish -= Exit;
        }
    }
}