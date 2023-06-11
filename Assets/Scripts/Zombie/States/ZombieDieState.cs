using UnityEngine;
using UnityEngine.Video;

namespace DefaultNamespace
{
    public class ZombieDieState : ZombieBaseState
    {
        public override void EnterState()
        {
            _zombie._animator.SetTrigger("died");
            _zombie._navMeshAgent.SetDestination(_zombie.transform.position);
        }

        public override void UpdateState()
        {
            
        }

        public override void OnCollisionState( Collision collision)
        {
            throw new System.NotImplementedException();
        }
    }
}