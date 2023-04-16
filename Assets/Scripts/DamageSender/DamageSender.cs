using UnityEngine;

namespace DefaultNamespace.DamageSender
{
    public class DamageSender : MonoBehaviour
    {
        public int _damage
        {
            get => damage;
            set
            {
                damage = value;
            }
        }

        [SerializeField] private int damage;

        public virtual void DealDame(Transform obj)
        {
            DamageReceiver damageReceiver;
            damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
            if(damageReceiver == null) return;
            this.DealDame(damageReceiver);
        }

        public virtual void DealDame(DamageReceiver damageReceiver)
        {
            damageReceiver.Deal(damage);
        }

        protected virtual void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}