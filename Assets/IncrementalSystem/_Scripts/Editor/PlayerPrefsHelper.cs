using UnityEditor;
using UnityEngine;
using IncrementalSystem.Scripts.Managers;
using IncrementalSystem.Scripts.Examples;

namespace IncrementalSystem.Scripts.Editor
{
    public class PlayerPrefsHelper : EditorWindow
    {
        private int _gold;

        [MenuItem("Custom Editor/Clear Player Prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Custom Editor/Set Gold")]
        public static void ShowWindow()
        {
            PlayerPrefsHelper window = GetWindow<PlayerPrefsHelper>();
            window.titleContent = new GUIContent("PlayerPrefs Editor");
        }

        private void OnGUI()
        {
            _gold = EditorGUILayout.IntField("Gold", _gold);

            if (GUILayout.Button("Increase Gold"))
            {
                GoldManager.Gold += _gold;
                UIManager.Ins.SetGoldText();
            }

            if (GUILayout.Button("Decrease Gold"))
            {
                GoldManager.Gold -= _gold;
                UIManager.Ins.SetGoldText();
            }

        }
    }
}
