using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {RESTAURANT, DUNGEON}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public OrderManager orderManager;

    [SerializeField] private GameState gameState = GameState.RESTAURANT;

    private void Awake() {
        if(instance != this && instance != null){
            Destroy(gameObject);

        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public static GameManager getInstance(){
        if(instance = null){
            instance = new GameManager();
        }

        return instance;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public GameState getCurrentState(){
        return gameState;
    }
}
