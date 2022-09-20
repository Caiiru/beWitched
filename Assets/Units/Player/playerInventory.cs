using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public IngredientData[] ingredientsDataList = new IngredientData[10];
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject item){
        
        
        var listsize = ingredientsDataList.Length;
    
        for(int i= 0; i<listsize; i++){
            if(ingredientsDataList[i] == null){
                ingredientsDataList[i] = item.GetComponent<Ingredient>().data;
                Destroy(item);
                break;
            }
        }

    }
}
