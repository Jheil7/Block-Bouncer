using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float forwardSpeed=2.0f;
    [SerializeField] float jumpSpeed;
    private Vector2 movement;
    private BoxCollider2D myCollider;
    public bool hasJumpAvailable;
    SpriteRenderer sprite;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        myCollider=GetComponent<BoxCollider2D>();
        hasJumpAvailable=false;
        sprite=GetComponent<SpriteRenderer>();
        playerInput=GetComponent<PlayerInput>();
        var index=playerInput.playerIndex;
        Debug.Log(index);
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate() {
        PlayerVelocity();
    }

    void PlayerVelocity(){
        Vector2 playerVelocity=new Vector2(forwardSpeed*movement.x*Time.deltaTime, rb.velocity.y);
        rb.velocity= playerVelocity;
    }

    void OnMove(InputValue value){
        
        movement=value.Get<Vector2>();
        
    }

    void OnJump(InputValue value){
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            hasJumpAvailable=true;
            if(value.isPressed&&hasJumpAvailable){
                rb.velocity=new Vector2(rb.velocity.x, 0.0f);
                rb.AddForce(transform.up*jumpSpeed);
                hasJumpAvailable=false;
            }     
        }
    }    

    void FlipSprite(){
        bool playerHasHorizontalSpeed= Mathf.Abs(rb.velocity.x)>0.1f;
        if(playerHasHorizontalSpeed==true){
            transform.localScale= new Vector2(-0.2f*Mathf.Sign(rb.velocity.x),0.2f);
        }
    }
}
