using UnityEngine;

public class RecipeBookUI : MonoBehaviour
{
    /*public static RecipeBookUI instance;
    //[SerializeField] private GameObject recipeBookUI;

    [SerializeField] private RecipePaperUI recipePaperPrefab;
    [SerializeField] private RectTransform contentPanel;

    public List<RecipePaperUI> listOfPaperUI = new List<RecipePaperUI>();

    [SerializeField] private RecipeDescriptionUI recipeDescription;*/

    /*[SerializeField] private TestGiveRecipe testGiveRecipe;*/

    /*private void Awake()
    {
        instance = this;
        Hide();
        recipeDescription.ResetDescription();

        GameManager.instance.LoadDataRecipe();
    }*/

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Pressed");
            if (recipeBookUI.activeInHierarchy == false)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
            
        GameManager.instance.SaveDataRecipe();
    }*/

    //RecipeSO
    /*public void AddRecipe()
    {
        RecipePaperUI paperUI = Instantiate(recipePaperPrefab, Vector3.zero, Quaternion.identity);
        paperUI.transform.SetParent(contentPanel);
        paperUI.transform.localScale = Vector3.one;
        paperUI.recipeSO = testGiveRecipe.GiveRecipeSO();   //gan recipeSO vao paperUI
        paperUI.SetData(paperUI.recipeSO.RecipeImage);
        listOfPaperUI.Add(paperUI);

        paperUI.OnPaperClicked += PaperUI_OnPaperClicked;
    }*/

    /*public void AddRecipe(RecipeSO recipeSO)
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
        Debug.Log("ItemClicked!!");
        Debug.Log(obj.transform.position);
        recipeDescription.SetDescription(obj.recipeSO.RecipeImage, obj.recipeSO.Title, obj.recipeSO.Benefit, obj.recipeSO.Ingredient);
        obj.Select();
    }

    //SaveData
    public RecipeSO SaveDataRecipe(int i)
    {
        if (listOfPaperUI[i] != null)
        {
            return listOfPaperUI[i].recipeSO;
        } else {
            return null;
        }
    }*/


    //Hide, Show
    public void Show()
    {
        gameObject.SetActive(true);
        //ResetSelection();
    }

    /*private void ResetSelection()
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
    }*/

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    

}
