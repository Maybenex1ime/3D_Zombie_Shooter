using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieDie : MonoBehaviour
    {
        private CapsuleCollider _collider;
        private Animator _animator;
        private Animator_Zombie _animatorZombie;
        private DamageReceiver _damageReceiver;
        private void Awake()
        {
            _collider = GetComponent<CapsuleCollider>();
            _animator = GetComponentInChildren<Animator>();
            _animatorZombie = GetComponent<Animator_Zombie>();
            _damageReceiver = GetComponent<DamageReceiver>();
        }

        private void Update()
        {
            if(BeDead()) Dead();
        }

        public void Dead()
        {
            _animator.SetTrigger("died");
            GetComponentInChildren<ParticleSystem>().Play();
            ZombieSpawner.instance.Despawn(this.transform);
        }

        protected virtual bool BeDead()
        {
            return _damageReceiver.isDead();
        }
    }
}