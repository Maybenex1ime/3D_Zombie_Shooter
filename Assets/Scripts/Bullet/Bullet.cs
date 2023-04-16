using System;
using DefaultNamespace;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        public GameObject _DamageDealer { get; private set; }

        public Transform _firePoint;
        private Rigidbody _rb;

        private void Awake()
        {
            _firePoint = BulletSpawner.instance._firePoint;
            _DamageDealer = transform.Find("DamageDealer").gameObject;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.AddForce(_firePoint.forward * 10, ForceMode.Impulse);
        }
    }
}