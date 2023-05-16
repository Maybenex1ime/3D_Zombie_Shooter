using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class CharController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private PlayerCamera _camera;
        public NavMeshData _data;
        public Transform _orientation;
        #if UNITY_EDITOR
        private SerializedProperty _m_offMeshLinks;
        #endif
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _camera = GetComponentInChildren<PlayerCamera>();
#if UNITY_EDITOR
            _m_offMeshLinks = new SerializedObject(_data).FindProperty("m_OffMeshLinks");
#endif
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
#if UNITY_EDITOR          
                #region NavMeshLink

                bool flag = false;
                    for (int i = 0; i< _m_offMeshLinks.arraySize; ++i)
                {
                    Vector3 startPosition = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_Start").vector3Value;
                    Vector3 endPosition = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_End").vector3Value;
                    float radius = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_Radius").floatValue;
                    if (radius >= Vector3.Distance(startPosition, this.transform.position))
                    {
                        _navMeshAgent.SetDestination(endPosition);
                        flag = true;
                        break;
                    }
                }
                
                #endregion

                if(flag == false) _navMeshAgent.SetDestination(movePosition);
#endif
                _navMeshAgent.SetDestination(movePosition);
            }
            else
            {
                _navMeshAgent.SetDestination(transform.position);
            }
            #endregion
            
            #region Shooting

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
            {
                #if UNITY_EDITOR
                Debug.Log("EDITOR");              
                #endif
                var from = _camera.transform.position;
                var direction = _camera.transform.forward; 
                BulletSpawner.instance.Show(from,direction);
            }

            #endregion
        }
    }
}