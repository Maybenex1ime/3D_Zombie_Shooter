using UnityEngine;

namespace Interact
{
    [CreateAssetMenu(menuName = "Interact/Explode", fileName = "Explode")]
    public class Explode : InteractEffect
    {
        public override void Apply(GameObject target)
        {
            target.GetComponent<Explodable>().nowExplode();
        }
    }
}