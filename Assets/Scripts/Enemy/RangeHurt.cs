using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class RangeHurt : MonoBehaviour
    {
        [SerializeField] private bool isHurt;

        private bool wait;

        private void Awake()
        {
            isHurt = false;

            wait = false;
        }

        private void Update()
        {
            if (isHurt && !wait)
            {
                StartCoroutine(Wait());
                wait = true;
            }
        }

        public IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.5f);
            isHurt = false;
            wait = false;
        }

        public bool GetIsHurt()
        {
            return isHurt;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Sword")
            {
                isHurt = true;
            }
        }
    }
}
