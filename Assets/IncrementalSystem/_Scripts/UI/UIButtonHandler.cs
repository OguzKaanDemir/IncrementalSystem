using TMPro;
using UnityEngine;

namespace IncrementalSystem.Scripts.UI
{
    public class UIButtonHandler : MonoBehaviour
    {
        private static UIButtonHandler _ins;
        public static UIButtonHandler Ins
        {
            get
            {
                if (!_ins)
                    _ins = FindObjectOfType<UIButtonHandler>();
                return _ins;
            }
        }

        public enum TextType { notEnoughMoney, maxLevel }
        public GameObject textPrefab;
        public float textSpeed;
        public float animDuration; 
        public Color notEnoughMoneyColor;
        public Color maxLevelColor;

        public void OnButtonClick(TextType type, Vector3 incrementaItemPos)
        {
            var newText = Instantiate(textPrefab, incrementaItemPos, Quaternion.identity, transform);
            var tmp = newText.GetComponentInChildren<TMP_Text>();
            tmp.text = type == TextType.notEnoughMoney ? "Not Enough Money" : "Max Level";
            tmp.color = type == TextType.notEnoughMoney ? notEnoughMoneyColor : maxLevelColor;
        }
    }
}
