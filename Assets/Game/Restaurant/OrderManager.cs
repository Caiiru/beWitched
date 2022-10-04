using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public GameObject blankFood;
    public Sprite Gororoba;
    public Sprite burnedFood;
    private void Awake() {
        if(instance != this && instance !=null){
            Destroy(gameObject);
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public RecipeData[] recipes;

    public int[] test = new int[] {1,2,3};
    
    

    void Start()
    {
        
        Array.Sort(recipes);
    }

    public GameObject Mix(List<GameObject>ingredients){
        foreach(var r in recipes){
            int loop = 0;
            foreach (var i in ingredients){
                if(i.GetComponent<IngredientData>().check()){
                    if(i.GetComponent<IngredientData>().data._name == r.ingredients[loop].data._name){
                        bool isCuttedRight= i.GetComponent<IngredientData>().isCutted().Equals(r.ingredients[loop].isCut);
                        bool isFryiedRight = i.GetComponent<IngredientData>().isFried().Equals(r.ingredients[loop].isFry);
                        
                        if(isCuttedRight&& isFryiedRight){
                        }

                    }

                }
                
                loop++;
            }
        }
        
        return null;
    }


}
[System.Serializable]
public class RecipeData{
    public string _name;
    public ingredienteData[] ingredients;
    [PreviewSprite]public Sprite recipeSprite;
}

[System.Serializable]
public class ingredienteData{
    public string name;
    public Ingredient data;
    public bool isFry;
    public bool isCut;
    private void Awake() {
        
        name = data._name;
    }
     private void OnValidate() {

        name = data._name;
    }
}
