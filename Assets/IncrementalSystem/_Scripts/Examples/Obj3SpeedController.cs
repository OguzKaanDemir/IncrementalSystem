using UnityEngine;
using IncrementalSystem.Scripts.Incremental;

namespace IncrementalSystem.Scripts.Examples
{
    public class Obj3SpeedController : MonoBehaviour
    {
        public void XSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(2, 0, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }

        public void YSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(2, 1, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }

        public void ZSpeedAction()
        {
            IncrementalFunctionLogic.IncrementalFunction(2, 2, () => { /* Do Somethig Here */ UIManager.Ins.SetGoldText(); });
        }
    }
}
