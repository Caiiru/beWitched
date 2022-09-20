using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Order", menuName ="ScriptableObjects/Orders/OrderData")]
public class OrderData : ScriptableObject
{
    public new string name;
    public Sprite IngredientSprite;
    public Color ingredientColor;
}
