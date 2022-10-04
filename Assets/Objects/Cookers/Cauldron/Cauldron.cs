using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour, BaseItem
{
    [SerializeField] int maxCookTime = 0;
    int currentCookTime=0;
    int burnTime;
    [SerializeField]bool isActive;
    public List<GameObject> holdedObjects = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject player){
        var hold = player.GetComponent<playerHold>();
        if(hold.getIsHolding()){
            if(holdedObjects.Count<=3){
                addToCauldron(hold.GetHoldObject());
            }
            else
                CannotAddMore();
        }
        else{
            if(isActive==false)
                ActivateCouldron();
            else{
                isActive=false;
                hold.Hold(OrderManager.instance.Mix(holdedObjects));

            }

        }
    }

    private void addToCauldron(GameObject ingredient){
        holdedObjects.Add(ingredient);
        maxCookTime+= ingredient.GetComponent<IngredientData>().getCookTime();
        burnTime = maxCookTime*2;
    }
    private void CannotAddMore(){

    }
    void ActivateCouldron(){
        isActive=true;
        maxCookTime=0;
        currentCookTime=0;
        foreach(var i in holdedObjects){
            maxCookTime+=i.GetComponent<IngredientData>().getCookTime();
        }
        StartCoroutine(Cook());
    }
    IEnumerator Cook(){
        yield return new WaitForSeconds(1); 
        currentCookTime+=1;
        /*
        if(currentCookTime>= maxCookTime && currentCookTime<=burnTime){
            foreach (var i in holdedObjects){
                i.GetComponent<IngredientData>().setStage(ingredientStage.Fryed);

            }
        }
        */
        if(isActive)
            StartCoroutine(Cook());
    }

    public int getMaxCookTime(){
        return maxCookTime;
    }
    public int getCurrentCookTime(){
        return currentCookTime;
    }
}
