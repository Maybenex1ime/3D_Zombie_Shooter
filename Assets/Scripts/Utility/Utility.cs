using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Utility
{
    public class Utility
    {
        public static Utility instance = new Utility();

        private Utility()
        {
            
        }

        public OffMeshLink CastToOffMeshLink(SerializedProperty _property)
        {
            SerializedProperty startProperty = _property.FindPropertyRelative("m_Start");
            SerializedProperty endProperty = _property.FindPropertyRelative("m_End");
            SerializedProperty areaProperty = _property.FindPropertyRelative("m_Area");
            SerializedProperty bidirectionalProperty = _property.FindPropertyRelative("m_Bidirectional");
            SerializedProperty activatedProperty = _property.FindPropertyRelative("m_Activated");
            SerializedProperty costOverrideProperty = _property.FindPropertyRelative("m_CostOverride");
            SerializedProperty radiusProperty = _property.FindPropertyRelative("m_Radius");
            Debug.Log(radiusProperty.floatValue);

            OffMeshLink linkData = new OffMeshLink();
            linkData.startTransform.position = startProperty.vector3Value ;
            linkData.endTransform.position = endProperty.vector3Value;
            linkData.area = areaProperty.intValue;
            linkData.biDirectional = bidirectionalProperty.boolValue;
            linkData.activated = activatedProperty.boolValue;
            linkData.costOverride = costOverrideProperty.floatValue;

            Debug.Log(linkData.area);
            return linkData;
        }
    }
}