using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public int health = 0;
    public int maxHealth = 20;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    
    private Transform player;
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Vector2.Distance(transform.position,player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed*Time.deltaTime);
        }
    }
    public void TakeDamage(int dmg){
        health-=dmg;
        if(health<= 0){KillEnemy();}
    }
    public void KillEnemy(){
        if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        {
            GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
        }
        Destroy(this.gameObject);

    }

      void OnDestroy()
    {
       
     
    }
}
