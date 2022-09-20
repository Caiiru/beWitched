using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour,BaseItem
{
    public OrderData[] possibleOrders = new OrderData[3];
    public IngredientData[] orders = new IngredientData[3];
    public bool canInteract;
    private bool haveBeenOrdered= false;
    public GameObject orderImage;
    private GameObject speechBaloom;
    private void Start() {
        speechBaloom = transform.GetChild(0).gameObject;
        speechBaloom.SetActive(false);
    }
    public void Interact(GameObject player){
        if(canInteract){
            if(!haveBeenOrdered){
                speechBaloom.SetActive(true);
                //Futuramente fazer uma state machine com os estados -> Chegando, Esperando para Fazer o pedido, esperando o pedido, indo embora
                int orderNumber = Random.Range(0,3);
                OrderData order  = possibleOrders[orderNumber];
                orderImage.GetComponent<SpriteRenderer>().color = order.ingredientColor;
                haveBeenOrdered=true;


            }

        }
    }
    

}
