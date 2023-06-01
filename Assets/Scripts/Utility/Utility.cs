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
            string assetPath = "Assets/RPG_FPS_game_assets_industrial/Map_v1/NavMesh.asset"; // Replace with the actual path to your ".asset" file

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
#endif
    }
        

}