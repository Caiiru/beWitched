using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Recipe", menuName ="ScriptableObjects/Recipes")]
public class Recipe : ScriptableObject
{
    
    public string _name;
    //public Ingredient[] ingredients;
    
    public IngredientData[] ingredients;
    [PreviewSprite]public Sprite recipeSprite;


    private void OnValidate() {
        
    }
}
