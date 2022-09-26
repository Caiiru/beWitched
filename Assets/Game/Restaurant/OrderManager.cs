using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    private void Awake() {
        if(instance != this && instance !=null){
            Destroy(gameObject);
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public Recipe[] recipes;


    void Start()
    {
        
    }

    public bool Mix(List<GameObject>ingredients){
        var currentIngredients = ingredients.ToArray();

        return false;
    }
}
