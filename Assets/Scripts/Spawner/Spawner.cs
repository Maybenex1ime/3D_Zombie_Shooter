using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] protected Transform holder;
        [SerializeField] private List<Transform> prefabs;
        [SerializeField] protected List<Transform> poolObj;
        [SerializeField] private int _maxNum;
        protected string _prefabName;

        protected void  LoadComponents(string prefabName)
        {
            this._prefabName = prefabName;
            LoadHolder();
            LoadPrefabs();
        }

        protected virtual void LoadHolder()
        {
            if (this.holder != null) return;
            this.holder = transform.Find("Holder");
        }

        protected virtual void LoadPrefabs()
        {
            if (this.prefabs.Count > 0) return;

            Transform prefabObj = transform.Find(this._prefabName);
            if(prefabObj != null) this.prefabs.Add(prefabObj);
            HidePrefabs();
        }

        protected virtual void HidePrefabs()
        {
            foreach (Transform prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }

        public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation)
        {
            Transform prefab = this.getPrefabByName(this._prefabName);
            if (prefab == null)
            {
                Debug.LogWarning("Prefab not Found :"+ this._prefabName);
                return null;
            }

            Transform newPrefab = getObjectFromPool(prefab);
            newPrefab.SetPositionAndRotation(spawnPos,rotation);
            newPrefab.parent = holder;
            newPrefab.gameObject.SetActive(true);
            return newPrefab;
        }

        protected virtual Transform getObjectFromPool(Transform prefab)
        {
            foreach (Transform obj in this.poolObj)
            {
                this.poolObj.Remove(obj);
                return obj;
            }
            
            Transform newPrefab = Instantiate(prefab);
            newPrefab.name = prefab.name;
            return newPrefab;
        }
        
        public virtual void Despawn(Transform obj)
        {
            this.poolObj.Add(obj);
            
            obj.gameObject.SetActive(false);
        }

        public virtual Transform getPrefabByName(string prefabName)
        {
            foreach (Transform prefab in this.prefabs)
            {
                if (prefab.gameObject.name == prefabName)
                {
                    return prefab;
                }
            }

            return null;
        }
    }
}