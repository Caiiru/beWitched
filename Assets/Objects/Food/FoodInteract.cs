using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInteract : ItensPriority, BaseItem
{
    private bool canInteract =true;
    Transform holdPosition;
    private void Start() {
        canInteract=true;
        InteractPriority = 2;
    }
    public void Interact(GameObject player){
        
        if(canInteract){
            var interact = player.GetComponent<playerInteraction>();
            var hold = player.GetComponent<playerHold>();
            if(!hold.getIsHolding() && canInteract){
                hold.Hold(this.gameObject);
                return;
            }
            else{  
                hold.unHold();
            }

            

        }  

    }

}
