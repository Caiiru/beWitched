using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Ingredient", menuName ="ScriptableObjects/Ingredient")]
[System.Serializable]
public class Ingredient : ScriptableObject
{
    public string _name;

    [PreviewSprite] public Sprite sprite;
    [Range(1,10)] public int cookTime;

    public bool isFried = false;
}
