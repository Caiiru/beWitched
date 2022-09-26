using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Ingredient", menuName ="ScriptableObjects/Ingredient")]
[System.Serializable]
public class Ingredient : ScriptableObject
{
    public string _name;
    [Space]
    [Header("Sprites")]
    [PreviewSprite] public Sprite normal_sprite;
    [PreviewSprite] public Sprite fried_sprite;
    [PreviewSprite] public Sprite gororoba_sprite;

    [Space]
    [Header("Infos")]
    [Range(1,10)] public int cookTime;



}
