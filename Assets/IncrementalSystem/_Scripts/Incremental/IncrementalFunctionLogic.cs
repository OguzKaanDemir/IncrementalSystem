using System;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Incremental
{
    public class IncrementalFunctionLogic
    {
        public static void IncrementalFunction(int groupNo, int itemNo, Action act)
        {
            var incrementalItem = IncrementalItemManager.Ins.GetIncrementalItem(groupNo, itemNo);
            var item = IncrementalItemManager.Ins.GetItem(groupNo, itemNo);

            if (item.level < item.maxLevel && GoldManager.Gold > int.Parse(incrementalItem.costTMP.text))
            {
                GoldManager.Gold -= int.Parse(incrementalItem.costTMP.text);
                item.level++;
                incrementalItem.SetItem();

                act?.Invoke();
            }
        }
    }
}
