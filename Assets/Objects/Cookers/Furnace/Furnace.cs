using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : CookerData, BaseItem
{
    [SerializeField] private int CookTime;
    [SerializeField] Color furnaceColor;
    GameObject player;
    GameObject ingredient;
    public bool isHoldingIngredient= false;

    private bool isActive;
    
    void Start()
    {
        isActive=false;
        GetComponent<SpriteRenderer>().color = furnaceColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject player){
        this.player = player;
        playerHold hold = player.GetComponent<playerHold>();
        if(!isActive){
            if(hold.getIsHolding()){
                if(hold.GetHoldObject().CompareTag("Ingredient")){
                    ingredient = player.GetComponent<playerInteraction>().returnFirstFood();
                    hold.unHold();
                    ingredient.transform.position = transform.position;
                    //ingredient.GetComponent<Ingredient>().canInteract =false;
                    isActive=true;
                    isHoldingIngredient=true;
                    StartCoroutine(Cooking(ingredient));
                
                }
                else if(hold.GetHoldObject().CompareTag("Plate")){
                    if(ingredient!=null){
                        isHoldingIngredient=false;
                        ingredient.transform.position = hold.GetHoldObject().transform.position;
                        ingredient.GetComponent<FoodInteract>().Interact(player);
                    }
                }
                else{
                    Debug.Log("Empty hands");
                }
            }
            else if(isHoldingIngredient){
                isHoldingIngredient=false;
                ingredient.GetComponent<FoodInteract>().Interact(player);
            }
            else{
                Debug.Log("Empty hands");
            }

        }
        
        
        

    }
    IEnumerator Cooking(GameObject food){
        food.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(CookTime);
        isActive=false;
        food.GetComponent<SpriteRenderer>().enabled = true;
        //food.GetComponent<foodData>().Cook(type);
        food.GetComponent<IngredientData>().changeState(IngredientData.ingredientStage.Fry);
        isActive=false;
        
    }
}
