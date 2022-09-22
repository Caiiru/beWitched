using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInteract : ItensPriority, BaseItem
{
    public bool canInteract =false;
    private bool Holded;
    Transform holdPosition;
    public void Interact(GameObject player){
        if(canInteract){
            var interact = player.GetComponent<playerInteraction>();
            if(!interact.isHolding && canInteract){
                holdPosition =interact.grabPoint.transform;

                interact.isHolding=true;
                Holded=true;
            }
            else{   
                interact.canInteract= true; 
                interact.isHolding=false;
                Holded=false;
                interact = null;
                return;
            }

        }

    }

    private void Update() {
        if(Holded){
            this.transform.position = holdPosition.transform.position;
        }
    }
    public void setHoldPoint(Transform holdPoint){
        holdPosition = holdPoint;
        Holded=true;
    }

    private void Start() {
        canInteract=true;
    }
}
