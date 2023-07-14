using TMPro;
using UnityEngine;
using System.Collections.Generic;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _ins;
        public static UIManager Ins
        {
            get
            {
                if (!_ins)
                    _ins = FindObjectOfType<UIManager>();
                return _ins;
            }
        }

        [SerializeField] private List<GameObject> _incPanels = new();
        [SerializeField] private TMP_Text _objNameText;
        [SerializeField] private TMP_Text _goldText;

        private void Start()
        {
            SetGoldText();
        }

        public void OpenPanel(int i)
        {
            foreach (var item in _incPanels)
                item.SetActive(false);

            _incPanels[i].SetActive(true);
            _objNameText.text = _incPanels[i].name;
        }

        public void SetGoldText()
        {
            _goldText.text = "$" + GoldManager.Gold.ToString();
        }
    }
}
