using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Cauldron : ItensPriority, BaseItem
{
    [SerializeField] int maxCookTime = 0;
    int currentCookTime=0;
    int burnTime;
    [SerializeField]bool isActive;
    public bool isDone;
    //public List<GameObject> holdedObjects = new List<GameObject>();
    public GameObject[] holdedObjects;
    [Space]
    [Header("Components")]
     BoxCollider2D triggerCollider;
     GameObject canvas;


    void Start()
    {
        canvas = transform.GetChild(1).transform.gameObject;
        triggerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Interact(GameObject player){
        Debug.Log("Interact Cauldron");
        var hold = player.GetComponent<playerHold>();
        if(hold.getIsHolding() && !isActive && !hold.GetHoldObject().CompareTag("Plate")){ //Se tiver algo na mão e ele estiver desligado
           
            var loop  = 0 ;
            foreach(var o in holdedObjects){
                if(o == null){
                    print(loop);
                    //addToCauldron(hold.GetHoldObject());
                    holdedObjects[loop] = hold.GetHoldObject();
                    hold.unHold();
                    canvas.GetComponent<Cauldron_Canvas>().setSprite(holdedObjects);
                    holdedObjects[loop].SetActive(false);
                        
                    break;
                }
                loop++;
            }
            CannotAddMore();
        }
        else{
            if(isActive==false && !isDone)
                ActivateCouldron();
            if(isDone && hold.getIsHolding() &&  hold.GetHoldObject().CompareTag("Plate")){
                if(hold.GetHoldObject().GetComponent<plateScript>().isEmpty()){
                    print("IS DONE AND TRYING TO TAKE ");
                    isActive=false;
                    GameManager.instance.orderManager.Mix(holdedObjects);
                    //OrderManager.instance.sexo(holdedObjects.ToList());
                    //OrderManager.instance.printTest();
                    //hold.Hold(OrderManager.instance.Mix(holdedObjects));
                    canvas.GetComponent<Cauldron_Canvas>().isActive=false;
                    isDone=false;

                }
                

            }
            else{
                print("Error");
            }

        }
    }

    private void addToCauldron(GameObject ingredient){
        for (int i =0; i<3; i++){
            maxCookTime=0;
            var add=false;
            if(holdedObjects[i] == null && !add){
                holdedObjects[i]=ingredient;
                ingredient.SetActive(false);
                add=true;
            }
            maxCookTime+= ingredient.GetComponent<IngredientData>().getCookTime();
        }
        burnTime = maxCookTime*2;
        
    }
    private void desactivateCauldron(){
        isActive=false;
        currentCookTime=0;
        maxCookTime=0;
        
    }
    private void CannotAddMore(){
        print("Cannot add more");
    }
    void ActivateCouldron(){
        maxCookTime=0;
        foreach(var ob in holdedObjects){
            if(ob!= null)
                maxCookTime+=ob.GetComponent<IngredientData>().getCookTime();
        }
        currentCookTime=0;
        isActive=true;
        StartCoroutine(Cook());
    }
    IEnumerator Cook(){
        print("Cooking " + currentCookTime + "/"+maxCookTime);
        canvas.GetComponent<Cauldron_Canvas>().setSlide(currentCookTime,maxCookTime);
        yield return new WaitForSeconds(1);
        if(currentCookTime<maxCookTime){
            currentCookTime++;
            StartCoroutine(Cook());
        }
        else{
            print("Is done");
            isDone=true;
        }

    }

    public int getMaxCookTime(){
        return maxCookTime;
    }
    public int getCurrentCookTime(){
        return currentCookTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            canvas.GetComponent<Cauldron_Canvas>().isNearbyActivate();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(canvas.GetComponent<Cauldron_Canvas>().desactivateCanvas());
        }
    }
}
