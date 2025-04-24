using System;
using Interact;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [CustomEditor(typeof(PowerUpSpawner))]
    public class PowerUpSpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            PowerUpSpawner spawner = (PowerUpSpawner)target;
            if (GUILayout.Button("Spawn PowerUps"))
            {
                spawner.Spawn(Vector3.zero, Quaternion.identity);
            }
            base.OnInspectorGUI();
        }
    }
    
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
            Debug.Log("Spawn Powerups");
            return base.Spawn(spawnPos, rotation);
        }
    }
}