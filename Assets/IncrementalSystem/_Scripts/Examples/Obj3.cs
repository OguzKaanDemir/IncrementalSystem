using UnityEngine;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Examples
{
    public class Obj3 : MonoBehaviour
    {
        public int xSpeed => 5 + IncrementalItemManager.Ins.GetItem(2, 0).level * 2;
        public int ySpeed => 3 + IncrementalItemManager.Ins.GetItem(2, 1).level * 2;
        public int zSpeed => 1 + IncrementalItemManager.Ins.GetItem(2, 2).level * 2;

        private void Update()
        {
            transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            UIManager.Ins.OpenPanel(2);
        }
    }
}