using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using IncrementalSystem.Scripts.Helpers;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Managers
{
    [CreateAssetMenu(fileName = "IncrementalItemManager", menuName = "IncrementalItemManager")]
    [HideIf(nameof(_costs), nameof(_costsFromCustom))]
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

        /// <summary>
        /// Gets the item based on the specified group number and item number.
        /// </summary>
        /// <param name="groupNo">The group number of the item.</param>
        /// <param name="itemNo">The item number within the group.</param>
        /// <returns>The item with the specified group number and item number.</returns>
        public Item GetItem(int groupNo, int itemNo)
        {
            return items[groupNo].itemList[itemNo];
        }

        /// <summary>
        /// Gets the incremental item based on the specified group number and item number.
        /// </summary>
        /// <param name="groupNo">The group number of the incremental item.</param>
        /// <param name="itemNo">The item number within the group.</param>
        /// <returns>The incremental item with the specified group number and item number.</returns>
        public IncrementalItem GetIncrementalItem(int groupNo, int itemNo)
        {
            var items = FindObjectsOfType<IncrementalItem>();

            return items.First(x => x.groupNo == groupNo && x.itemNo == itemNo);
        }
        #endregion

        #region Cost

        /// <summary>
        /// Gets the cost value based on the specified level.
        /// </summary>
        /// <param name="level">The level for which to calculate the cost.</param>
        /// <returns>The cost value.</returns>
        public int GetCost(int level)
        {
            if (_costsFromCustom)
                return _costs[level];

            else
                return _customCost.Cost(level);
        }

        
        private class CustomCost
        {
            private int _startValue = 50;

            /// <summary>
            /// Your custom cost algorithm here.
            /// </summary>
            public int Cost(int level)
            {
                var newValue = _startValue + level * 20;
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