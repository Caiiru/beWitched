using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IngredientData : MonoBehaviour     
{
    public enum ingredientStage{
    Normal,
    Fry,
    Cut,
    Burned
}
    [Header("Sprites")]
    public Ingredient data;
    
    [Header("Informations")]
    [SerializeField][Range(0,10f)] int cookTime;
    [SerializeField][Range(0f,100f)] int frieValue;
    [SerializeField] ingredientStage stage;

    [HideInInspector]
    public new string name;
    private string _name;
    SpriteRenderer SPrenderer;

    private void Start() {
        SPrenderer = GetComponent<SpriteRenderer>();
        SPrenderer.sprite = data.normal_sprite;
        _name = data._name;
        changeSprite();
    }
    void changeSprite(){
        switch(stage){
            case ingredientStage.Normal:
            SPrenderer.sprite = data.normal_sprite;
            name = _name;
            break;
            case ingredientStage.Fry:
            SPrenderer.sprite = data.fried_sprite;
            name=_name+"_fry";
            break;
            case ingredientStage.Cut:
            SPrenderer.sprite = data.cutted_sprite;
            name=_name+"_cut";
            break;
            case ingredientStage.Burned:
            SPrenderer.sprite = data.slime_sprite;
            name=_name+"_burned";
            break;
        }
        transform.name= name;
    }

    public int getCookTime(){
        return cookTime; 
    }

    public void setData(Ingredient newdata){
        data = newdata;
        cookTime = newdata.cookTime;
    }
    public void changeState(ingredientStage state){
        stage = state;
        changeSprite();
    }

}
   