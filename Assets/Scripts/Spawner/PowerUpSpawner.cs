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
                spawner.Spawn(new Vector3(0,0.4f,0), Quaternion.identity);
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
            Transform target = base.Spawn(spawnPos, rotation);
            target.localScale = Vector3.one * 50;
            return target;
        }
    }
}