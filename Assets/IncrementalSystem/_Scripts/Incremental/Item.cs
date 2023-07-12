using UnityEngine;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Incremental
{
    [System.Serializable]
    public class Item
    {
        public string itemPPKey => $"Group{GetIndexes()[0]}Item{GetIndexes()[1]}";
        public string title;
        public Sprite sprite;
        public int level
        {
            get
            {
                return PlayerPrefs.GetInt(itemPPKey, 0);
            }
            set
            {
                PlayerPrefs.SetInt(itemPPKey, value);
            }
        }
        public int maxLevel;

        private int[] GetIndexes()
        {
            IncrementalItemManager itemManager = IncrementalItemManager.Ins;
            int groupIndex = itemManager.items.FindIndex(itemList => itemList.itemList.Contains(this));
            int itemIndex = itemManager.items[groupIndex].itemList.IndexOf(this);
            return new int[] { groupIndex, itemIndex };
        }
    }
}

