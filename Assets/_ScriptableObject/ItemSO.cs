using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Only Gameplay")]
    public ItemType type;

    [Header("Only UI")]
    public bool stackable = true;   //determine if the item should be stacked in the inventory

    [Header("Both")]
    public Sprite image;
    public string name;
    public int health;
    public int stamina;
}

public enum ItemType
{
    Ingredient,
    Food
}