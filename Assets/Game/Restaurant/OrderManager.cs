using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class OrderManager : MonoBehaviour
{
    public GameObject genericFood;

    
    //public List<RecipeData> recipes = new List<RecipeData>();
    public RecipeData[] recipes;
    public GameObject[] enterIngredients;

    public GameObject outputFood;
    public Sprite GororobaSprite;
    public Ingredient gororobaData;

    [Space]
    [Header("Debug")]
    public bool active = false;
    private void Start() {
        foreach(var r in recipes){
            foreach(var i in r.ingredients){
                i.Start();
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Mix(enterIngredients);
        }
        if(active){
            active=false;
            Mix(enterIngredients);
        }
    }
    Sprite spriteTemp;

    public void printTest(){
        print("So");
    }
    public GameObject Mix(GameObject[] inputIngredients){
        enterIngredients=inputIngredients;
        var loop = 0;
        var equals = 0;
        
        
        foreach(var r in recipes){
            var secondLoop=0;
            foreach(var i in r.ingredients){
                if((r.ingredients.Length) != secondLoop){
                    if(inputIngredients[secondLoop] == null)
                        break;
                    if(i.name== inputIngredients[secondLoop].name){
                        equals++;
                    }
                    secondLoop++;  
                }
            } 
            Debug.Log("Equals: " + equals + " Length: " + r.ingredients.Length);
            if(equals == r.ingredients.Length && inputIngredients.Length == equals){
                Debug.Log("Accept");
                spriteTemp = r.recipe_sprite;
                GameObject temp=  Instantiate(genericFood, new Vector3(0,0, 1), Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().sprite = spriteTemp; 
                temp.name =  r.name;
                Array.Clear(enterIngredients,0,enterIngredients.Length);
                return temp;
            }
            loop++;
        }
        var gororoba = Instantiate(genericFood, new Vector3(0,0,1),Quaternion.identity);
        gororoba.GetComponent<SpriteRenderer>().sprite = GororobaSprite;
        gororoba.name = "Gororoba";
        gororoba.GetComponent<IngredientData>().data = gororobaData;
        gororoba.layer = LayerMask.NameToLayer("InteractableLayer");
        gororoba.AddComponent<BoxCollider2D>().isTrigger=true;
        
        Array.Clear(enterIngredients,0,enterIngredients.Length);
        return gororoba;

        
    }

}


[System.Serializable]
public class RecipeData{
    public string name;
    [PreviewSprite] public Sprite recipe_sprite;
    public ingredienteData[] ingredients;
}


[System.Serializable]
public class ingredienteData{
    public string name;
    public Ingredient data;
    public bool isFry;
    public bool isCut;
    public void Start() {
        name = data._name;
        if(isFry){
            name = data._name + "_fry";
        }
        else if( isCut )
            name = data._name + "_cut";
    }
    
} 


