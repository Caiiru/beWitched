using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Recipe", menuName ="ScriptableObjects/Recipes")]
public class Recipe : ScriptableObject
{
    
    public string _name;
    [PreviewSprite]public Sprite recipeSprite;
    public Ingredient[] ingredients;

    [Space]

    public float totalCookTime;
    public bool isFinished;

    private void OnValidate() {
        totalCookTime=0;
        foreach(var item in ingredients){
            if(item!=null)
                totalCookTime += item.cookTime;
        }
    }
}
