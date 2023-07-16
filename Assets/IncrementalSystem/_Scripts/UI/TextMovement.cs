using UnityEngine;

namespace IncrementalSystem.Scripts.UI
{
    public class TextMovement : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, UIButtonHandler.Ins.animDuration);
        }

        private void Update()
        {
            transform.Translate(Vector3.up * UIButtonHandler.Ins.textSpeed * Time.deltaTime );
        }
    }
}
