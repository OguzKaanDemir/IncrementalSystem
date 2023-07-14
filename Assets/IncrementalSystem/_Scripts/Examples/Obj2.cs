using UnityEngine;
using IncrementalSystem.Scripts.Managers;

namespace IncrementalSystem.Scripts.Examples
{
    public class Obj2 : MonoBehaviour
    {
        public float xRange;
        public float yRange;
        public float xSpeed => .3f + IncrementalItemManager.Ins.GetItem(1, 0).level / 10f;
        public float ySpeed => .4f + IncrementalItemManager.Ins.GetItem(1, 1).level / 10f;

        private float _xStartPosition;
        private float _yStartPosition;
        private float _xTargetPosition;
        private float _yTargetPosition;

        private int _xIndex;
        private int _yIndex;

        private void Start()
        {
            _xStartPosition = transform.position.x;
            _yStartPosition = transform.position.y;
            _xTargetPosition = _xStartPosition + xRange;
            _yTargetPosition = _yStartPosition + yRange;
        }

        private void Update()
        {
            float xStep = xSpeed * Time.deltaTime;
            float yStep = ySpeed * Time.deltaTime;

            float newXPosition = Mathf.MoveTowards(transform.position.x, _xTargetPosition, xStep);
            float newYPosition = Mathf.MoveTowards(transform.position.y, _yTargetPosition, yStep);

            transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);


            if (Mathf.Abs(transform.position.x - _xTargetPosition) < .1f)
            {
                _xIndex++;
                if (_xIndex % 2 == 0)
                    _xTargetPosition = _xStartPosition + xRange;
                else
                    _xTargetPosition = _xStartPosition - xRange;
            }

            if (Mathf.Abs(transform.position.y - _yTargetPosition) < .1f)
            {
                _yIndex++;
                if (_yIndex % 2 == 0)
                    _yTargetPosition = _yStartPosition + yRange;
                else
                    _yTargetPosition = _yStartPosition - yRange;
            }
        }

        private void OnMouseDown()
        {
            UIManager.Ins.OpenPanel(1);
        }
    }
}
