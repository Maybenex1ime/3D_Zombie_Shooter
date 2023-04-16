using DefaultNamespace;
using UnityEngine;

namespace Bullet
{
    public class BulletDespawned : MonoBehaviour
    {
        [SerializeField] protected float distance;
        [SerializeField] private float disLimit;
        [SerializeField] private Transform mainCam;

        protected virtual void Despawning()
        {
            if (!this.CanDespawn()) return;
            this.Despawn();
        }

        protected virtual bool CanDespawn()
        {
            this.distance = Vector3.Distance(transform.position, this.mainCam.position);
            if (this.distance > this.disLimit) return true;
            return false;
        }

        public virtual void Despawn()
        {
            BulletSpawner.instance.Despawn(this.transform);
        }
    }
}