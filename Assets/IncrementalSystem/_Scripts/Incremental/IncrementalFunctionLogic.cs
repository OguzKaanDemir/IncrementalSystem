using System;
using IncrementalSystem.Scripts.UI;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Incremental
{
    public class IncrementalFunctionLogic
    {
        /// <summary>
        /// Executes an incremental function for the specified group number and item number.
        /// </summary>
        /// <param name="groupNo">The group number of the incremental function.</param>
        /// <param name="itemNo">The item number within the group.</param>
        /// <param name="act">An action to be invoked after executing the incremental function.</param>
        public static void IncrementalFunction(int groupNo, int itemNo, Action act)
        {
            var incrementalItem = IncrementalItemManager.Ins.GetIncrementalItem(groupNo, itemNo);
            var item = IncrementalItemManager.Ins.GetItem(groupNo, itemNo);

            if(item.level == item.maxLevel)
            {
                UIButtonHandler.Ins.OnButtonClick(UIButtonHandler.TextType.maxLevel, incrementalItem.transform.position);
            }
            else if (GoldManager.Gold < int.Parse(incrementalItem.costTMP.text))
            {
                UIButtonHandler.Ins.OnButtonClick(UIButtonHandler.TextType.notEnoughMoney, incrementalItem.transform.position);
            }
            else
            {
                GoldManager.Gold -= int.Parse(incrementalItem.costTMP.text);
                item.level++;
                incrementalItem.SetItem();

                act?.Invoke();
            }
        }
    }
}
