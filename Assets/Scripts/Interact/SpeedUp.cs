using UnityEngine;
using UnityEngine.AI;

namespace Interact
{
    [CreateAssetMenu(menuName = "Interact/SpeedUp", fileName = "SpeedUp")]
    public class SpeedUp: InteractEffect
    {
        public override void Apply(GameObject target)
        {
            target.GetComponent<NavMeshAgent>().speed = target.GetComponent<NavMeshAgent>().speed * 2;
        }
    }
}