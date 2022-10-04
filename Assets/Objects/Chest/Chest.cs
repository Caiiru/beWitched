using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : ItensPriority,BaseItem
{
    public int amount = 5;
    public int maxAmount = 10;
    public TextMeshProUGUI textShowAmount;


    private GameObject playerTemporary;
    public Ingredient ingredient;

    [SerializeField] GameObject genericFood;


    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Interact(GameObject player){
        playerTemporary = player;
        
        if(!player.GetComponent<playerHold>().getIsHolding()){
            
            
            if(amount>0){
                var food = Instantiate(genericFood,player.GetComponent<playerInteraction>().grabPoint.transform.position,player.GetComponent<playerInteraction>().grabPoint.rotation);
                //var food = Instantiate(new GameObject("BlankIngredient"), player.GetComponent<playerInteraction>().grabPoint.transform.position, player.GetComponent<playerInteraction>().grabPoint.rotation);
                TransformIngredients(food,player);
                removeAmount(1);
            }
             
        }
        /*
        else{
            if(player.GetComponent<playerHold>().GetHoldObject().transform.GetComponent<foodData>().getData()==ingredient){
                if(amount<maxAmount){
                    Destroy(player.GetComponent<playerHold>().GetHoldObject());
                    addAmount(1);
                }
            } 
        }
        */

        updateText();
       
    }

    void updateText(){
        textShowAmount.text = amount + " / " + maxAmount;

    }
    public void addAmount(int add){
        amount+=add;
        if(amount >= maxAmount) amount = maxAmount;
    }
    public void removeAmount(int remove){
        amount -= remove;
        if(amount<= 0) amount = 0;
    }

    public void TransformIngredients(GameObject food, GameObject player){
        food.layer = LayerMask.NameToLayer("InteractableLayer");
        food.name = ingredient._name;
        //food.AddComponent<SpriteRenderer>().sprite = ingredient.sprite;
        food.GetComponent<SpriteRenderer>().sprite=ingredient.normal_sprite;
        food.AddComponent<BoxCollider2D>().isTrigger=true;
        food.GetComponent<foodData>().setData(ingredient);
        food.GetComponent<FoodInteract>().Interact(player);

    }
    
    
    IEnumerator setFoodOnHands(){
        yield return new WaitForSeconds(0.1f);
        Debug.Log(playerTemporary.name);
        
    }

}
