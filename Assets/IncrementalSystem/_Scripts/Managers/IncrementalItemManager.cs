using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Managers
{
    [CreateAssetMenu(fileName = "IncrementalItemManager", menuName = "IncrementalItemManager")]
    public class IncrementalItemManager : ScriptableObject
    {
        #region Singleton
        private static IncrementalItemManager _ins;
        public static IncrementalItemManager Ins
        {
            get
            {
                if (!_ins)
                    _ins = Resources.Load<IncrementalItemManager>("IncrementalItemManager");
                return _ins;
            }
        }
        #endregion

        #region Vars
        public GameObject itemPrefab;
        public List<ItemList> items = new();

        [SerializeField] private bool _costsFromArray;
        [SerializeField] private List<int> _costs = new();

        private CustomCost _customCost = new();
        #endregion

        #region Item
        public Item GetItem(int groupNo, int itemNo)
        {
            return items[groupNo].itemList[itemNo];
        }

        public IncrementalItem GetIncrementalItem(int groupNo, int itemNo)
        {
            var items = FindObjectsOfType<IncrementalItem>();

            return items.First(x => x.groupNo == groupNo && x.itemNo == itemNo);
        }
        #endregion

        #region Cost
        public int GetCost(int level)
        {
            if (_costsFromArray)
                return _costs[level];

            else
                return _customCost.Cost(level);
        }

        private class CustomCost
        {
            private int startValue = 50;

            public int Cost(int level)
            {
                var newValue = startValue += level * 20;
                return newValue;
            }
        }
        #endregion
    }

    [System.Serializable]
    public class ItemList
    {
        public List<Item> itemList = new();
    }
}