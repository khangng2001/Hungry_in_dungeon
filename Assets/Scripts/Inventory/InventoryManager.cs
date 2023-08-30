using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;    //singleton

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    [SerializeField] private int maxStackedItems = 5;
    public int tempMaxStackedItems = 5;

    [SerializeField] private List<GameObject> itemPrefab;
    [SerializeField] private GameObject player;

    int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
        tempMaxStackedItems = maxStackedItems;
    }

    private void Update()
    {
        if (Input.inputString != null)  //check if any key is pressed
        {
            bool isNumber = int.TryParse(Input.inputString, out int number); //check if the press key is a number
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
                UseItem(true);
                ResetSelectedSlot();
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        selectedSlot = newValue;
    }
    private void ResetSelectedSlot()
    {
        selectedSlot = -1;
    }

    public bool AddItem(ItemSO item)
    {
        //Check if any slots has the same item with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true; //stop executing this code any further and the item was added
            }
        }

        //Find any empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true; //stop executing this code any further and the item was add
            }
        }

        return false;
    }

    void SpawnNewItem(ItemSO item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    //use Item
    public ItemSO UseItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

        //use if the selected item is food
        if (itemInSlot.item.type == ItemType.Food)
        {
            if (itemInSlot != null)
            {
                ItemSO item = itemInSlot.item;
                if (use == true)
                {
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0)
                    {
                        Destroy(itemInSlot.gameObject);
                    }
                    else
                    {
                        itemInSlot.RefreshCount();
                    }
                }
                return item;
            }
        }
        return null;
    }

    //Swap Item
    public void SwapItem(InventoryItem item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
                newItemGo.GetComponent<InventoryItem>().SwapItem(item.item, item.count);    //attach ItemSO
                return;
            }
        }
    }

    //Drop Item
    public void DropItem(InventoryItem item)
    {
        item.count--;
        item.RefreshCount();
        if (item.count <= 0)
        {
            Destroy(item.gameObject);
        }
    }

    public void DropItemOnGround(InventoryItem item)
    {
        for (int i = 0; i < itemPrefab.Count; i++)
        {
            ItemObject itemO = itemPrefab[i].GetComponent<ItemObject>();
            if (itemO.GetItem() == item.item)
            {
                Instantiate(itemPrefab[i], player.transform.position, Quaternion.identity);
            }
        }
    }

    //Add Item when Load game
    public void LoadSpawnItem(ItemSO item, InventorySlot slot, int count)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.count = count;
        inventoryItem.InitialiseItem(item);
    }
}
