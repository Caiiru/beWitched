using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : ItensPriority, BaseItem
{
    public new string name;
    public bool canInteract;
    public Transform playerTransform;
    public bool isGrabbed;
    private playerInteraction playerInteraction;
    public IngredientData data;
    void Start()
    {   
        canInteract= true;
    }
    private void OnEnable() {
        Debug.Log(name + " Created");
        canInteract= true;
        isGrabbed=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbed)
            this.transform.position = playerTransform.position;

            
        
    }

    public void Interact(GameObject player){
        if(GameManager.instance.getCurrentState() == GameState.RESTAURANT){
            Debug.Log("Interact with "+ name);
            playerInteraction = player.GetComponent<playerInteraction>();
            if(!isGrabbed){
                if(canInteract){
                    playerInteraction.canInteract=false;
                    playerInteraction.isHolding=true;
                    playerTransform = player.transform.GetChild(1).transform;
                    isGrabbed=true;
                    canInteract=false;
                }
            }
            else{
                playerInteraction.canInteract=true;
                playerInteraction.isHolding=false;
                isGrabbed=false;
                canInteract=true;
                playerTransform=null;
                playerInteraction=null;
            }
        }
        else{
            player.GetComponent<playerInventory>().AddItem(this.gameObject);
        }
    }

    public void SetPlayerInteraction(playerInteraction player){
        this.playerInteraction = player;
    }
}
