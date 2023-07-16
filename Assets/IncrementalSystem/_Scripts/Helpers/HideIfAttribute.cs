using System;
using UnityEditor;

namespace IncrementalSystem.Scripts.Helpers
{
    public class HideIfAttribute : Attribute
    {
        public string propName;
        public string boolName;

        public HideIfAttribute(string propName, string boolName)
        {
            this.propName = propName;
            this.boolName = boolName;
        }
    }

    [CustomEditor(typeof(UnityEngine.Object), true)]
    [CanEditMultipleObjects()]
    public class CustomEditorr : Editor
    {
        private static Type _type;
        private string _hiddenProperty;

        protected virtual void OnEnable()
        {
            _type = this.target.GetType();
            var arr = _type.GetCustomAttributes(typeof(HideIfAttribute), true) as HideIfAttribute[];
            if (arr != null && arr.Length > 0)
            {
                foreach (var a in arr)
                {
                    _hiddenProperty = a.propName;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            this.DrawDefaultInspector();
        }

        public new bool DrawDefaultInspector()
        {
            this.serializedObject.Update();
            var result = DrawDefaultInspectorExcept(this.serializedObject, _hiddenProperty);
            this.serializedObject.ApplyModifiedProperties();

            return result;
        }

        public static bool DrawDefaultInspectorExcept(SerializedObject serializedObject, string propNotToDraw)
        {
            if (serializedObject == null) throw new ArgumentNullException("serializedObject");

            EditorGUI.BeginChangeCheck();
            var iterator = serializedObject.GetIterator();

            var arr = _type.GetCustomAttributes(typeof(HideIfAttribute), true) as HideIfAttribute[];
            SerializedProperty boolVariable = null;
            foreach (var a in arr)
            {
                boolVariable = serializedObject.FindProperty(a.boolName);
            }

            for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
            {
                if (propNotToDraw == null || !propNotToDraw.Contains(iterator.name) || !boolVariable.boolValue)
                {
                    EditorGUILayout.PropertyField(iterator, true);
                }
            }
            return EditorGUI.EndChangeCheck();
        }
    }
}