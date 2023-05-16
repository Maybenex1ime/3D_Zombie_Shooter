using System;
using Interact;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class PowerUpSpawner : Spawner
    {
        public static PowerUpSpawner instance;
        
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
            LoadComponents("PowerUpPrefab");
        }

        public override Transform Spawn(Vector3 spawnPos, Quaternion rotation)
        {
            int randomNum = Random.Range(1, 101);
            Transform prefab = this.getPrefabByName(_prefabName);
            if (randomNum < prefab.GetComponent<Interactable>()._interactEffect._DropChance)
            {
                //prefab.GetComponent<Interactable>().RandomEffect();
                return base.Spawn(spawnPos, rotation);
            }

            return null;
        }
    }
}