using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : CookerData, BaseItem
{
    [SerializeField] private int CookTime;
    [SerializeField] Color furnaceColor;
    GameObject player;
    GameObject ingredient;
    bool isHoldingIngredient= false;

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
        if(!isActive){
            if(isHoldingIngredient){
                isHoldingIngredient=false;
                ingredient.GetComponent<FoodInteract>().Interact(player);
            }
            else{
                if(player.GetComponent<playerHold>().getIsHolding()){
                    
                    ingredient = player.GetComponent<playerInteraction>().returnFirstFood();
                    var h = player.GetComponent<playerHold>();
                    h.unHold();
                    Debug.Log("Try");
                    ingredient.transform.position = transform.position;
                    //ingredient.GetComponent<Ingredient>().canInteract =false;
                    isActive=true;
                    isHoldingIngredient=true;
                    StartCoroutine(Cooking(ingredient));
                }

            }
        }
        

    }
    IEnumerator Cooking(GameObject food){
        food.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(CookTime);
        //food.GetComponent<Ingredient>().canInteract=true;
        isActive=false;
        food.GetComponent<SpriteRenderer>().enabled = true;
        food.GetComponent<foodData>().Cook(type);
        isActive=false;
        
    }
}
