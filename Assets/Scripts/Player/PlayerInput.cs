using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float horizontal;
        public float vertical;

        public Vector2 inputMosue;

        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            inputMosue = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
