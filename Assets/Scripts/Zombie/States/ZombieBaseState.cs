using UnityEngine;

namespace DefaultNamespace
{
    public abstract class ZombieBaseState
    {
        protected ZombieStateManager _zombie;

        public void SetStateManager(ZombieStateManager zombie)
        {
            _zombie = zombie;
        }
        
        abstract public void EnterState();

        abstract public void UpdateState();

        abstract public void OnCollisionState( Collision collision); 
    }
}