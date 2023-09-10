using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PanelClickAttack : MonoBehaviour, IPointerClickHandler
    {
        public bool attack = false;

        public SwordController swordController;

        public void OnPointerClick(PointerEventData eventData)
        {
            swordController.CLICK = true;
        }
    }
}
