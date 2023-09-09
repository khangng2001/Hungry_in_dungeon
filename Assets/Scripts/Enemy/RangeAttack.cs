using UnityEngine;

namespace Enemy
{
    public class RangeAttack : MonoBehaviour
    {
        [SerializeField] private bool isAttack;

        private void Awake()
        {
            isAttack = false;
        }

        public bool GetIsAttack()
        {
            return isAttack;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                isAttack = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                isAttack = false;
            }
        }
    }
}
