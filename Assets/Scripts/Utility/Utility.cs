using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using ScriptableObjects;

namespace Utility
{

    public class Utility
    {
        [Serializable]
        public class WrapperOffMeshLinkData
        {
            public Vector3 startPos;
            public Vector3 endPos;
            public float radius;
        }

#if UNITY_EDITOR
        [MenuItem("Custom/Convert Asset to Scriptable Object")]
        public static void ConvertAssetToScriptableObject()
        {
            string assetPath = "Assets/RPG_FPS_game_assets_industrial/Map_v1/NavMesh.asset"; 

            // Load the asset at the specified path
            NavMeshData asset = (NavMeshData)AssetDatabase.LoadAssetAtPath(assetPath, typeof(NavMeshData));

            if (asset != null)
            {
                NavMeshDataObject scriptableObject = (NavMeshDataObject)ScriptableObject.CreateInstance(typeof(NavMeshDataObject));
                
                // Copy the serialized data from the loaded asset to the new Scriptable Object
                SerializedProperty _m_offMeshLinks = new SerializedObject(asset).FindProperty("m_OffMeshLinks");
                for (int i = 0; i < _m_offMeshLinks.arraySize; ++i)
                {
                    WrapperOffMeshLinkData data = new WrapperOffMeshLinkData();
                    data.startPos = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_Start")
                        .vector3Value;
                    data.endPos = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_End")
                        .vector3Value;
                    data.radius = _m_offMeshLinks.GetArrayElementAtIndex(i).FindPropertyRelative("m_Radius").floatValue;
                    scriptableObject._datas.Add(data);
                    scriptableObject._example = data;
                }
                // Save the new Scriptable Object as an asset
                string newAssetPath = "Assets/Interact/NavMeshDataObject.asset"; // Replace with the desired path and filename
                AssetDatabase.CreateAsset(scriptableObject, newAssetPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Debug.Log("Asset converted to Scriptable Object.");
            }
            else
            {
                Debug.LogError("Failed to convert asset to Scriptable Object.");
            }
        }

        [MenuItem("Custom/AddBidirectionalNavMeshOffLink")]
        public static void AddBiDirectional()
        {
            // Load the asset at the specified path
            NavMeshDataObject asset = (NavMeshDataObject)AssetDatabase.LoadAssetAtPath("Assets/Interact/NavMeshDataObject.asset", typeof(NavMeshDataObject));
            
            GameObject _gameObject = GameObject.Find("OffMeshLink");

            if (asset != null)
            {
                foreach (WrapperOffMeshLinkData link in asset._datas)
                {
                    OffMeshLink _newlink = _gameObject.AddComponent<OffMeshLink>() as OffMeshLink;
                    _newlink.activated = true;
                    _newlink.startTransform.position = link.endPos;
                    _newlink.endTransform.position = link.startPos;
                    _newlink.biDirectional = false;
                    WrapperOffMeshLinkData _wrapper = new WrapperOffMeshLinkData();
                    _wrapper.startPos = link.endPos;
                    _wrapper.endPos = link.startPos;
                    _wrapper.radius = link.radius;
                    asset._datas.Add(_wrapper);
                }
                // Save the new Scriptable Object as an asset
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                Debug.Log("AddedBidirectinalOffMeshLink");
            }
            else
            {
                Debug.LogError("Failed");
            }
        }
#endif
    }
        

}