using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ingredientStage{
    Normal,
    Fryed,
    Burned,
}
[System.Serializable]
public class IngredientData : MonoBehaviour     
{
    [Header("Sprites")]
    public Sprite normal_sprite;
    public Sprite friyed_sprite;
    public Sprite burned_sprite;
    public Ingredient data;
    
    [Header("Informations")]
    [SerializeField][Range(0,10f)] int cookTime;
    [SerializeField][Range(0f,100f)] int frieValue;
    [SerializeField] ingredientStage stage = ingredientStage.Normal;
    [SerializeField] bool isFry;
    [SerializeField] bool isBurned;
    [SerializeField] bool isCut;

    private bool isChecked;

    [HideInInspector]
    public string _name;
    SpriteRenderer SPrenderer;

    private void Start() {
        SPrenderer = GetComponent<SpriteRenderer>();
        SPrenderer.sprite = data.normal_sprite;
    }


    public bool check(){
        if(isChecked){
            return false;

        }
        else{
            isChecked=true;
            return true;
        }
    }
    public void setStage(ingredientStage s){
        stage = s;
    }

    public int getCookTime(){
        return cookTime; 
    }
    public bool isCutted(){
        return isCut;    
    }
    public bool isFried(){
        if(frieValue>80){
            isFry= true;
        }
        else
            isFry=false;

        return isFry;
    }

    private void OnValidate() {
        this.name = data._name;
    }

}
