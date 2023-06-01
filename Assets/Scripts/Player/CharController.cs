using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace DefaultNamespace
{
    public class CharController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerCamera _camera;
        public Transform _orientation;
        private List<Utility.Utility.WrapperOffMeshLinkData> _links;
        [SerializeField] private NavMeshDataObject _data;
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _camera = GetComponentInChildren<PlayerCamera>();
            _links = _data._datas;
        }

        private void Update()
        {
            #region Deead

            if (GetComponent<DamageReceiver>().isDead())
            {
                Application.Quit();
            }

            #endregion
            
            #region Movement

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            transform.rotation = _orientation.transform.rotation;

            if (x != 0 || y != 0)
            {
                Vector3 moveDirection = _orientation.forward * y + _orientation.right * x;
                Vector3 movePosition = transform.position + moveDirection;
      
                #region NavMeshLink

                bool flag = false;
                    for (int i = 0; i< _links.Count; ++i)
                {
                    if (_links[i].radius >= Vector3.Distance(_links[i].startPos, this.transform.position))
                    {
                        _navMeshAgent.SetDestination(_links[i].endPos);
                        flag = true;
                        break;
                    }
                }
                    #endregion
                if(flag == false) _navMeshAgent.SetDestination(movePosition);
            }
            else
            {
                _navMeshAgent.SetDestination(transform.position);
            }
            #endregion
            
            #region Shooting

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
            {
                var from = _camera.transform.position;
                var direction = _camera.transform.forward; 
                BulletSpawner.instance.Show(from,direction);
            }

            #endregion
        }
    }
}