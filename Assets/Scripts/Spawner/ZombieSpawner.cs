using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZombieSpawner : Spawner
    {
        public static ZombieSpawner instance;
        [SerializeField] private List<Transform> _spawnPoses;
        [SerializeField] private float _spawnRate;
        private float _tick;
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
            LoadComponents("ZombiePrefab");
        }
        
        private void Update()
        {
            Spawning();
        }

        private void Spawning()
        {
            if (_tick <= 0)
            {
                foreach (Transform spawnPos in _spawnPoses)
                {
                    Transform _newZombie = Spawn(spawnPos.localPosition, spawnPos.rotation);
                    _newZombie.GetComponent<DamageReceiver>().Reborn();
                }

                _tick = _spawnRate;
            }
            else
            {
                _tick -= Time.deltaTime;
            }
            
        }
    }
}