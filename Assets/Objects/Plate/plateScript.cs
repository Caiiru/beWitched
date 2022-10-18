using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateScript : ItensPriority,BaseItem
{
    private bool canInteract = true;
    public List<GameObject> holdedIngredients = new List<GameObject>();
    public Ingredient[] datas;
    private bool isGettingHolded = false;
    private void Start() {
        
        InteractPriority = 1;
    }
    
    
    public void Interact(GameObject player){
        print("Interact plate");
        var hold = player.GetComponent<playerHold>();
        if(hold.getIsHolding() && hold.GetHoldObject().CompareTag("Ingredient")){
            var ob = hold.GetHoldObject();
            ob.transform.parent = this.transform;
            holdedIngredients.Add(ob);
            hold.unHold();
        }
        else{
            if(isGettingHolded){
                isGettingHolded = false;
                hold.unHold();
            }
            else{
                isGettingHolded=true;
                hold.Hold(this.gameObject);
                //this.transform.parent = player.transform;
            }
        }
        /*
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
        */
    }
    private void Update() {
        foreach(var i in holdedIngredients){
            i.transform.position=this.transform.position;
        }
    }
    public bool isEmpty(){
        if(holdedIngredients.Count == 0){
            return true;
        }
        else
            return false;
    }
}
