using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Canvas hudMenu;

    [Header("Inventory")]
    public List<ItemSO> item;   //item.length = inventorySlot.length = 7
    public List<int> count;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        hudMenu = gameObject.GetComponentInChildren<Canvas>();
        
    }

    public void SaveDataInventory()
    {
        for (int i = 0; i < item.Count; i++)
        {
            item[i] = InventoryManager.instance.SaveDataItem(i);
            count[i] = InventoryManager.instance.SaveDataCount(i);
        }
    }

    public void LoadDataInventory()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i] != null)
            {
                InventoryManager.instance.LoadData(i, item[i], count[i]);
            }
        }
    }

   
    
}
