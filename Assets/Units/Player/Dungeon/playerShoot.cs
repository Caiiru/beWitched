using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerInputs))]
[RequireComponent(typeof(playerMovement))]
public class playerShoot : MonoBehaviour
{
    private playerInputs input;
    private playerMovement movement;
    private Vector2 directionBuffer;
    public Transform firePoint;
    public GameObject bullet;

    [SerializeField]private bool canShoot = false;
    void Start()
    {
        movement = GetComponent<playerMovement>();
        input = GetComponent<playerInputs>();
        if(GameManager.instance.getCurrentState() == GameState.DUNGEON)
            canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.getPosition()!= Vector2.zero)
            directionBuffer = movement.getPosition();
        if(input.shootInput() && canShoot){
            GameObject b = Instantiate(bullet,transform.position,transform.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(directionBuffer*10f, ForceMode2D.Impulse);
        }
    }
}
