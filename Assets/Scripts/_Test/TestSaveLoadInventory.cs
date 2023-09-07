using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoadInventory : MonoBehaviour
{
    public InventorySlot[] inventorySlots; 
    public ItemSO[] item;
    public string[] itemName;

    public int position, count;
    public string id;

    //upload data
    public void SaveInventory()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Debug.Log("i: " + i + ",name: " + itemInSlot.item.name + ",count: " + itemInSlot.count);
            }
        }
    }

    /*public void LoadInventory()
    {
        //clear items in slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Destroy(itemInSlot.gameObject);
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            LoadInventory(position, id, count);
        }
    }*/

    //download data
    private void ClearAllItem()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                Destroy(itemInSlot.gameObject);
            }
        }
    }
    public void LoadInventory(int position, string id, int count)
    {
        ClearAllItem();
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventoryItem itemInSlot = inventorySlots[position].GetComponentInChildren<InventoryItem>();
            if (itemName[i] == id && itemInSlot == null)
            {
                InventoryManager.instance.LoadSpawnItem(item[i], inventorySlots[position], count);

                return;
            }
            else
            {
                Debug.Log(": " + item[i].id);
            }
        }

        /*//when the inventory is empty, spawn item
        for (int i = 0; i < inventorySlots.Length; i++) //run loop slot
        {
            if (i == position) //if right slot
            {
                Debug.Log(i);
                for (int j = 0; j < item.Length; j++)    //run loop recipeList
                {
                    if (item[j].name == name)    //if same name
                    {
                        InventorySlot slot = inventorySlots[i];
                        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

                        InventoryManager.instance.AddItem(item[j]);
                        itemInSlot.count = count;

                        return;
                    }
                }
            }
        }*/
    }
}
