using UnityEngine;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Examples
{
    public class Obj2SpeedController : MonoBehaviour
    {
        public void XSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(1, 0, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }

        public void YSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(1, 1, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }
    }
}
