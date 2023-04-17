using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BulletSpawner : Spawner
    {
        public static BulletSpawner instance ;
        [SerializeField] private float distance;
        private DamageSender.DamageSender _DamageSender;
        private LineRenderer _lineRenderer;
        private bool visible;

        public ParticleSystem _muzzleFlash;
        
        public Transform _firePoint
        {
            get => firePoint;
            set
            {
                firePoint = value;
            }
        }

        [SerializeField] private Transform firePoint;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _DamageSender = GetComponent<DamageSender.DamageSender>();
            LoadComponents("BulletPrefab");
        }

        private void FixedUpdate()
        {
            if (visible) visible = false;
            else gameObject.SetActive(false);
        }

        public void Show(Vector3 from, Vector3 dir)
        {

            _muzzleFlash.Play();
            
            #region CollideDetect

            RaycastHit _raycast;
            Physics.Raycast(from, dir, out _raycast, distance);
            Vector3 to = new Vector3(_raycast.point.x, from.y, _raycast.point.y);

            if (_raycast.transform != null)
            {
                var zombie = _raycast.transform.GetComponent<ZombieDie>();
                if (zombie != null)
                {
                    _DamageSender.DealDame(zombie.transform);
                }
            }

            #endregion
            _lineRenderer.SetPositions(new Vector3[]{from, to});
            visible = true;
            gameObject.SetActive(true);
        }

        public void Shoot(Vector3 from, Vector3 dir)
        {
            GameObject bullet = BulletSpawner.instance.Spawn(from, firePoint.rotation).gameObject;
        }
    }
}