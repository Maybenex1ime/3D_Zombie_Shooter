using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieRunningState : ZombieBaseState
    {
        public override void EnterState()
        {
            _zombie._navMeshAgent.updateRotation = false;
        }

        public override void UpdateState()
        {
            if (Vector3.Distance(_zombie.transform.position, _zombie._player.transform.position) < _zombie._distanceToAttack)
            {
                _zombie.ChangeState(_zombie.AttackState);
            }
            
            _zombie._navMeshAgent.SetDestination(_zombie._player.transform.position);
            _zombie.transform.rotation = Quaternion.LookRotation(_zombie._navMeshAgent.velocity.normalized);

            #region Animator
            _zombie._animator.SetFloat("speed", _zombie._navMeshAgent.velocity.magnitude);
            #endregion

        }

        public override void OnCollisionState(Collision collision)
        {
            
        }
    }
}