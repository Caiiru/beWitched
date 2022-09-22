using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : ItensPriority, BaseItem
{
    [SerializeField] private int CookTime;
    [SerializeField] Color furnaceColor;
    GameObject player;
    GameObject ingredient;

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
        if(player.GetComponent<playerInteraction>().isHolding && !isActive){
            ingredient = player.GetComponent<playerInteraction>().returnFirstFood();
            ingredient.transform.position = transform.position;
            ingredient.GetComponent<Ingredient>().canInteract =false;
            isActive=true;
            player.GetComponent<playerInteraction>().isHolding=false;
            StartCoroutine(Cooking(ingredient));
        }

    }
    IEnumerator Cooking(GameObject food){
        food.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(CookTime);
        food.GetComponent<Ingredient>().canInteract=true;
        isActive=false;
        food.GetComponent<SpriteRenderer>().enabled = true;
        food.GetComponent<SpriteRenderer>().color = furnaceColor;
        
    }
}
