using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Incremental
{
    public class IncrementalItem : MonoBehaviour
    {
        public int groupNo;
        public int itemNo;

        public TMP_Text titleTMP;
        public Image image;
        public TMP_Text costTMP;
        public GameObject dollarTMP;
        public TMP_Text levelTMP;

        private void Start()
        {
            SetItem();
        }

        /// <summary>
        /// Sets the properties of the incremental item.
        /// </summary>
        public void SetItem()
        {
            var item = IncrementalItemManager.Ins.GetItem(groupNo, itemNo);
            titleTMP.text = item.title;
            image.sprite = item.sprite;

            if (item.level == item.maxLevel)
            {
                costTMP.text = string.Empty;
                levelTMP.text = $"Lvl. Max";
                dollarTMP.SetActive(false);
            }
            else
            {
                int cost = IncrementalItemManager.Ins.GetCost(item.level);
                costTMP.text = cost.ToString();
                levelTMP.text = $"Lvl. {item.level}";
            }
        }
    }
}