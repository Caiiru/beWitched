using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chest : ItensPriority,BaseItem
{
    public int amount = 5;
    public int maxAmount = 10;
    public TextMeshProUGUI textShowAmount;

    public IngredientData ingredientData;
    public GameObject genericFood;

    private GameObject playerTemporary;

    private IngredientData[] listTemporary;
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        listTemporary = player.GetComponent<playerInventory>().ingredientsDataList;
        for(int i = 0; i<listTemporary.Length; i++){
            if(listTemporary[i] != null){
                amount+=1;
                listTemporary[i] = null;
            }
        }
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Interact(GameObject player){
        playerTemporary = player;
        if(player.GetComponent<playerInteraction>().isHolding == false){
            if(amount>0){
                GenerateFood(ingredientData);
                var food = Instantiate(genericFood,player.GetComponent<playerInteraction>().grabPoint.transform.position,player.GetComponent<playerInteraction>().grabPoint.rotation);
                food.layer = LayerMask.NameToLayer("InteractableLayer");
                removeAmount(1);
                player.GetComponent<playerInteraction>().isHolding = true;
                food.GetComponent<Ingredient>().Interact(player);
                //food.GetComponent<Ingredient>().isGrabbed= true;
            }
        }
        updateText();
    }

    public void updateText(){
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
    
    public void GenerateFood(IngredientData data){
        genericFood.GetComponent<Ingredient>().name = data.name;
        genericFood.GetComponent<SpriteRenderer>().sprite = data.IngredientSprite;
        genericFood.GetComponent<CircleCollider2D>().isTrigger=true;
        genericFood.GetComponent<Ingredient>().canInteract = true;
        genericFood.GetComponent<Ingredient>().isGrabbed=false;
        genericFood.GetComponent<Ingredient>().SetPlayerInteraction(playerTemporary.GetComponent<playerInteraction>());
        
    }
    IEnumerator setFoodOnHands(){
        yield return new WaitForSeconds(0.1f);
        Debug.Log(playerTemporary.name);
        
    }
}
