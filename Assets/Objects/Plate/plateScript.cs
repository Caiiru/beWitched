using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateScript : ItensPriority,BaseItem
{
    private bool canInteract = true;
    public List<GameObject> holdedIngredients = new List<GameObject>();
    public Ingredient[] datas;
    private void Start() {
        
        InteractPriority = 1;
    }
    public void Interact(GameObject player){
        var p = player.GetComponent<playerHold>();
        var interact = player.GetComponent<playerInteraction>();
        if(p.getIsHolding() == true){
            if(p.GetHoldObject() != this.gameObject){
                holdedIngredients.Add(p.GetHoldObject());
                var go = p.GetHoldObject();
                int i=0;
                go.transform.parent = this.transform;
                foreach(var obj in holdedIngredients){
                    
                    datas[i] = obj.transform.GetComponent<Ingredient>();
                    i++;
                }
                
            }
            p.unHold();
          
        }
        else{

            if(!p.getIsHolding() && canInteract){
                p.Hold(this.gameObject);
                return;
            }
            else{  
                p.unHold();
            }
        }

    }
    private void Update() {
        foreach(var i in holdedIngredients){
            i.transform.position=this.transform.position;
        }
    }
}
