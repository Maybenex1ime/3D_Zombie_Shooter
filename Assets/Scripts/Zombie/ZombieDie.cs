using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieDie : MonoBehaviour
    {
        private Animator _animator;
        private Zombie _movement;
        
        private DamageReceiver _damageReceiver;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _damageReceiver = GetComponent<DamageReceiver>();
            _movement = GetComponent<Zombie>();
        }

        private void Update()
        {
            if(BeDead()) TriggerDied();
        }

        public void TriggerDied()
        {
            _animator.SetTrigger("died");
            _movement.Stop();

        }

        public void Dead()
        {
            GetComponentInChildren<ParticleSystem>().Play();
            ZombieSpawner.instance.Despawn(this.transform);
        }

        public virtual bool BeDead()
        {
            return _damageReceiver.isDead();
        }
    }
}