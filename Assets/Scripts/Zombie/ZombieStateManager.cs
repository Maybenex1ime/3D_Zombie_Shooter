using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class ZombieStateManager : MonoBehaviour
    {
        private ZombieBaseState currentState;
        public ZombieRunningState RunningState = new ZombieRunningState();
        public ZombieDieState DieState = new ZombieDieState();
        public ZombieAttackState AttackState = new ZombieAttackState();

        public ZombieStateManager instance;
        public NavMeshAgent _navMeshAgent;
        public CharController _player;
        public Animator _animator;
        public ParticleSystem _muzzleFlash;
        public DamageReceiver _DamageReceiver;
        public DamageSender.DamageSender _DamageSender;
        public float _distanceToAttack;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<CharController>();
            _animator = GetComponent<Animator>();
            _muzzleFlash = GetComponentInChildren<ParticleSystem>();
            _DamageReceiver = GetComponent<DamageReceiver>();
            _DamageSender = GetComponent<DamageSender.DamageSender>();
            RunningState.SetStateManager(this);
            DieState.SetStateManager(this);
            AttackState.SetStateManager(this);
        }

        private void Start()
        {
            currentState = RunningState;
            currentState.EnterState();
        }

        private void Update()
        {
            if(_DamageReceiver.isDead()) ChangeState(DieState);
            currentState.UpdateState();
        }

        public void Dead()
        {
            this._muzzleFlash.Play();
            ZombieSpawner.instance.Despawn(this.transform);
        }

        IEnumerator RunParticleSystem()
        {
            this._muzzleFlash.Play();
            yield return new WaitForSeconds(2);
        }
        
        public void ChangeState(ZombieBaseState state)
        {
            currentState = state;
            state.EnterState();
        }

        public void ChangeStateWrapper(ZombieState state)
        {
            switch (state)
            {
                case ZombieState.RUNNING:
                {
                    ChangeState(RunningState);
                    break;
                }
                case ZombieState.ATTACK:
                {
                    ChangeState(AttackState);
                    break;
                }
                case ZombieState.DIE:
                {
                    ChangeState(DieState);
                    break;
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.transform.name);
            currentState.OnCollisionState(collision);
        }

        public void DealDameToPlayer()
        {
            _DamageSender.DealDame(_player.transform);
        }
    }
}