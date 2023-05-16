using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Interact
{
    [CreateAssetMenu(menuName = "Interact/SpeedUp", fileName = "SpeedUp")]
    public class SpeedUp: InteractEffect
    {
        private GameObject _target;
        private int _speedUp = 7;
        private float _speedNor = 3.5f;
        public override void Apply(GameObject target)
        {
            if(_target == null) _target = target;
            _target.GetComponent<NavMeshAgent>().speed = _speedUp;
        }

        public override void UnApply()
        {
            _target.GetComponent<NavMeshAgent>().speed = _speedNor;
        }
    }
}