using System.Collections.Generic;
using UnityEngine;

public class TestGiveRecipe : MonoBehaviour
{
    //this script maybe for drawf

    [SerializeField] private List<RecipeSO> recipePapers;

    public void GiveRecipe()
    {
        if (RecipeManager.instance.listOfPaperUI.Count == 0 )
        {
            AddRecipe();
        } else
        {
            //if (coinPaper >= 1)
                AddRecipe();
        }
    }

    public void AddRecipe()
    {
        RecipeManager.instance.AddRecipe(recipePapers[0]);
        recipePapers.Remove(recipePapers[0]);
        GameManager.instance.SaveDataRecipe();
    }
}
