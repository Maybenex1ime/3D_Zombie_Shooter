using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NavMeshDataObject", menuName = "NavMeshDataSO", order = 0)]
    public class NavMeshDataObject : ScriptableObject
    {
        public List<Utility.Utility.WrapperOffMeshLinkData> _datas = new List<Utility.Utility.WrapperOffMeshLinkData>();
        public Utility.Utility.WrapperOffMeshLinkData _example;
    }
}