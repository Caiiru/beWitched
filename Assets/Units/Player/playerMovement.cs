using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum PLAYER { Player1, Player2}
public class playerMovement : MonoBehaviour
{
    
    [Range(0, 10)]
    [SerializeField]private float moveSpeed =5f ;
    [SerializeField] PLAYER player; 
    public GameObject sprite;
    private Rigidbody2D rb2D;
    private Vector2 position;
    private Animator animator;
    void Start()
    {
         rb2D = GetComponent<Rigidbody2D>();
         animator = sprite.GetComponent<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        position.x = horizontalInput();
        position.y = verticalInput();
        if(position != Vector2.zero){
            animator.SetFloat("horizontal",position.x);
            animator.SetFloat("vertical",position.y);
            animator.SetFloat("speed",position.sqrMagnitude);
        }
    
    }

        private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + new Vector2(position.x,position.y) * moveSpeed * Time.fixedDeltaTime); 
    }
      public Vector2 getPosition()
    {
        return position;
    }

     float horizontalInput(){
        if(player == PLAYER.Player1){
            return Input.GetAxisRaw("Horizontal");
        }
        else{
            return Input.GetAxisRaw("Horizontal2");
        }
    }
    float verticalInput(){
        if(player == PLAYER.Player1){
            return Input.GetAxisRaw("Vertical");
        }
        else{
            return Input.GetAxisRaw("Vertical2");
        }
    }
}
