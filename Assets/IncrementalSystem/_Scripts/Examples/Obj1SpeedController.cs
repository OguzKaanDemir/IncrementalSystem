using UnityEngine;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Examples
{
    public class Obj1SpeedController : MonoBehaviour
    {
        public void XSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(0, 0, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }

        public void YSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(0, 1, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }

        public void ZSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(0, 2, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }
    }
}
