using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ingredient", menuName ="ScriptableObjects/Ingredients/IngredientData")]
public class IngredientData : ScriptableObject
{
    public new string name;
    public Sprite IngredientSprite;
    
}
