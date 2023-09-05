using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager instance;

    [SerializeField] private RecipePaperUI recipePaperPrefab;
    [SerializeField] private RectTransform contentPanel;

    public List<RecipePaperUI> listOfPaperUI = new List<RecipePaperUI>();

    [SerializeField] private RecipeDescriptionUI recipeDescription;

    [SerializeField] private RecipeBookUI recipeBookUI;

    private void Awake()
    {
        instance = this;
        recipeBookUI.Hide();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (recipeBookUI.isActiveAndEnabled == false)
            {
                recipeBookUI.Show();
                ResetSelection();
            }
            else
            {
                recipeBookUI.Hide();
            }
        }

        GameManager.instance.SaveDataRecipe();
    }

    public void AddRecipe(RecipeSO recipeSO)
    {
        RecipePaperUI paperUI = Instantiate(recipePaperPrefab, Vector3.zero, Quaternion.identity);
        paperUI.transform.SetParent(contentPanel);
        paperUI.recipeSO = recipeSO;
        paperUI.SetData(paperUI.recipeSO.RecipeImage);
        listOfPaperUI.Add(paperUI);

        paperUI.OnPaperClicked += PaperUI_OnPaperClicked;
    }

    private void PaperUI_OnPaperClicked(RecipePaperUI obj)
    {
        ResetSelection();
        recipeDescription.SetDescription(obj.recipeSO.RecipeImage, obj.recipeSO.Title, obj.recipeSO.Benefit, obj.recipeSO.Ingredient);
        obj.Select();
    }

    //SaveData
    public RecipeSO SaveDataRecipe(int i)
    {
        if (listOfPaperUI[i] != null)
        {
            return listOfPaperUI[i].recipeSO;
        }
        else
        {
            return null;
        }
    }

    //Hide, Show
    private void ResetSelection()
    {
        recipeDescription.ResetDescription();
        DeSelectionAllItems();
    }

    private void DeSelectionAllItems()
    {
        foreach (RecipePaperUI item in listOfPaperUI)
        {
            item.Deselect();
        }
    }
}
