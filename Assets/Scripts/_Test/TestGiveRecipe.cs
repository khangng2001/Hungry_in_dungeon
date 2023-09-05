using System.Collections.Generic;
using UnityEngine;

public class TestGiveRecipe : MonoBehaviour
{
    //this script maybe for drawf

    [SerializeField] private List<RecipeSO> recipePapers;

    public RecipeSO RandomRecipeSO()
    {
        RecipeSO temp = new RecipeSO();
        temp = recipePapers[0];
        recipePapers.Remove(recipePapers[0]);
        return temp;
    }

    public RecipeSO GiveRecipeSO()
    {
        return RandomRecipeSO();
    }

    public void AddRecipe()
    {
        RecipeManager.instance.AddRecipe(recipePapers[0]);
        GameManager.instance.SaveDataRecipe();
        recipePapers.Remove(recipePapers[0]);
    }
}
