using DefaultNamespace;
using UnityEngine;

namespace Interact
{
    [CreateAssetMenu(menuName = "Interact/Healthregen", fileName = "HealthRegen")]
    public class HealthRegen : InteractEffect
    {
        public int HealAmount;
        public override void Apply(GameObject target)
        {
            target.GetComponent<DamageReceiver>().Heal(HealAmount);
        }
    }
}