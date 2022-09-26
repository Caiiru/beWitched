using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Ingredients2
{
    public string _name;
    [Space]
    [Header("Sprites")]
    public Ingredient ingredientData;
    [Space]
    [Header("Informations")]
    public bool isFried;


}