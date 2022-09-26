using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum currentStage{
    NONE,
    FRIED,
    GOROROBA
    
}
public class foodData : MonoBehaviour
{
    [SerializeField]Ingredient ingredientData;
    [SerializeField]currentStage stage;
    [SerializeField]bool isFried;
    [SerializeField]bool isGororoba; //quando for impossivel comer
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cook(typeOfCook type){
        switch(type){
            case typeOfCook.FRY:
                if(stage == currentStage.NONE){
                    stage = currentStage.FRIED;
                    GetComponent<SpriteRenderer>().sprite = ingredientData.fried_sprite;
                }
                else{
                    stage=currentStage.GOROROBA;
                    GetComponent<SpriteRenderer>().sprite = ingredientData.gororoba_sprite;
                }
            break;
        }
    }
    public void setData(Ingredient data){
        ingredientData = data;
    }
    public Ingredient getData(){
        return ingredientData;
    }
}
