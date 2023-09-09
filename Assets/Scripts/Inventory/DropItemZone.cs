using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class DropItemZone : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();  //get the item

            InventoryManager.instance.DropItemOnGround(inventoryItem);
            InventoryManager.instance.DropItem(inventoryItem);
        }
    }
}
