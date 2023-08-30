using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public event EventHandler<OnProgressBarChangedEventArgs> OnProgressBarChanged;
    public class OnProgressBarChangedEventArgs : EventArgs
    {
        public float progressBarNormalized;
    }

    [SerializeField] private float cookingProgressMax;
    [SerializeField] private float cookingProgressTimer;

    public static CookingManager instance;

    [SerializeField] private CookingUI cookingUI;

    public CookingSlot[] cookingSlots;
    [SerializeField] private GameObject resultSlot;
    [SerializeField] private GameObject cookBtn;
    [SerializeField] private GameObject cookBar;
    [SerializeField] private bool open = false;   //check resultSlot open or not

    public List<ItemSO> itemList;
    [SerializeField] private string[] recipes;
    [SerializeField] private ItemSO[] recipeResults;
    [SerializeField] private GameObject inventoryItemPrefab;

    private string tempRecipeString;
    private string tempRecipeStringS;

    private enum State {
        Idle,       //when nothing cooking
        Cooking,    //when the player click CookBtn
        Cooked      //when the CookBar is full
    }
    private State state;

    private void Awake()
    {
        cookingUI.Hide();
        cookBtn.SetActive(false);
    }

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cookingUI.isActiveAndEnabled == false)
            {
                cookingUI.Show();
                open = true;
            }
            else
            {
                cookingUI.Hide();
                open = false;
            }
        }

        //run CookBar
        if (open)
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Cooking:
                    cookBtn.SetActive(false);

                    //update CookBarUI
                    cookingProgressTimer += Time.deltaTime;
                    OnProgressBarChanged?.Invoke(this, new OnProgressBarChangedEventArgs
                    {
                        progressBarNormalized = cookingProgressTimer / cookingProgressMax
                    });

                    if (cookingProgressTimer > cookingProgressMax)
                    {
                        //spawn food
                        InventoryItem itemInSlot = resultSlot.GetComponentInChildren<InventoryItem>();
                        for (int i = 0; i < recipes.Length; i++)
                        {
                            if (recipes[i] == tempRecipeStringS)
                            {
                                if (itemInSlot == null)
                                    SpawnFood(recipeResults[i]);
                            }
                        }

                        //switch State
                        state = State.Cooked;
                    }
                    break;
                case State.Cooked:
                    //update UI
                    cookingProgressTimer = 0f;
                    OnProgressBarChanged?.Invoke(this, new OnProgressBarChangedEventArgs
                    {
                        progressBarNormalized = cookingProgressTimer
                    });

                    //switch State
                    state = State.Idle;
                    break;
            }
        }

        CheckForCreatedRecipe();
        CheckItemEqualZero();
    }

    private void CheckForCreatedRecipe()
    {
        if (open)
        {
            for (int i = 0; i < cookingSlots.Length; i++)
            {
                InventoryItem itemInSlot = cookingSlots[i].GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null)
                {
                    itemList[i] = itemInSlot.item;
                }
            }

            string currentRecipeString = "";
            foreach (ItemSO item in itemList)
            {
                if (item != null)
                {
                    currentRecipeString += item.name;
                } else {
                    currentRecipeString += "null";
                }
            }

            for (int i = 0; i < recipes.Length; i++)
            {
                InventoryItem itemInSlot = resultSlot.GetComponentInChildren<InventoryItem>();
                if (recipes[i] == currentRecipeString)
                {
                    if (itemInSlot == null)
                    {
                        cookBtn.SetActive(true);
                    }
                }
                if (itemInSlot != null || tempRecipeString != currentRecipeString || cookBar.activeInHierarchy == true)
                {
                    cookBtn.SetActive(false);
                }
            }
            tempRecipeString = currentRecipeString;
        }
    }

    public void SpawnFood(ItemSO food)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, resultSlot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(food);
    }

    public void Cooking()
    {
        cookBtn.SetActive(false);   //hide cookButton
        tempRecipeStringS = tempRecipeString;
        state = State.Cooking;      //switch state
        cookingProgressTimer = 0f;
        OnClickResultSlot();        //sub ingredients
    }

    public void OnClickResultSlot() //ingrediens--
    {
        for(int i = 0; i < cookingSlots.Length; i++)
        {
            InventoryItem itemInSlot = cookingSlots[i].GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
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
        }
        CheckForCreatedRecipe();
    }

    public void CheckItemEqualZero()    //check if itemInSlot is null -> remove ItemSO in itemList
    {
        for (int i = 0; i < cookingSlots.Length; i++)
        {
            InventoryItem itemInSlot = cookingSlots[i].GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                itemList[i] = null;
            }
        }
    }
}
