using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieAttackState : ZombieBaseState
    {
        public override void EnterState()
        {
            Attack();
        }

        public override void UpdateState()
        {
            if (Vector3.Distance(_zombie.transform.position, _zombie._player.transform.position) > _zombie._distanceToAttack)
            {
                _zombie.ChangeState(_zombie.RunningState);
            }
        }

        public override void OnCollisionState(Collision collision)
        {
        }

        public void Attack()
        {
            _zombie._animator.SetTrigger("attack");
            
        }
        
    }
}