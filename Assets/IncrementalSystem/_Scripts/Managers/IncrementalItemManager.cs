using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using IncrementalSystem.Scripts.Helpers;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Managers
{
    [CreateAssetMenu(fileName = "IncrementalItemManager", menuName = "IncrementalItemManager")]
    [HidePropertyInInspector(nameof(_costs), nameof(_costsFromCustom))]
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
        public List<ItemList> items = new();

        [SerializeField] private bool _costsFromCustom;
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
            if (_costsFromCustom)
                return _costs[level];

            else
                return _customCost.Cost(level);
        }

        private class CustomCost
        {
            private int startValue = 50;

            public int Cost(int level)
            {
                var newValue = startValue + level * 20;
                return newValue;
            }
        }
        #endregion
    }

    [System.Serializable]
    public class ItemList
    {
        public string name;
        public List<Item> itemList = new();
    }
}