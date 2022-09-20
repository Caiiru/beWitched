using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : ItensPriority, BaseItem
{
    [SerializeField] private int CookTime;
    [SerializeField] Color furnaceColor;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ingredient;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().color = furnaceColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject player){
        this.player = player;
        if(player.GetComponent<playerInteraction>().isHolding){
            player.GetComponent<playerInteraction>().isHolding=false;
            ingredient = player.GetComponent<playerInteraction>().returnFirstFood();
            ingredient.transform.position = transform.position;
            ingredient.GetComponent<Ingredient>().canInteract =false;
            StartCoroutine(Cooking(ingredient));
        }

    }
    IEnumerator Cooking(GameObject food){
        food.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(CookTime);
        food.GetComponent<Ingredient>().canInteract=true;
        food.GetComponent<SpriteRenderer>().enabled = true;
        food.GetComponent<SpriteRenderer>().color = furnaceColor;
        
    }
}
