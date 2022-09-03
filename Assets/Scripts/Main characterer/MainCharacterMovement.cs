using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    float dirX, dirZ;
    public float moveSpeedBase;
   // public float jumpForce;
    private Rigidbody2D player;

    public string state;
    private string air = "air";
    private string floor = "floor";

    private float jumpTimeCounter;
    public float jumpTime;
    public float jumpForce;
    private bool isJumping;
    public float moveSpeed;
    private float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        //state = floor;
    }

    // Update is called once per frame
    void FixedUpdate() {
         
        dirX = Input.GetAxisRaw("Horizontal");
        if(dirX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(dirX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        moveSpeed = moveSpeedBase;
        Vector2 movement = new Vector2(dirX * moveSpeed, player.velocity.y);
        player.velocity = movement;  
    }
    
    void Update(){
        KeyInputs();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Ground") state = floor;
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(state == floor){
            if(other.gameObject.tag == "Ground") state = air;
        }
    }

    private void KeyInputs(){
        if(Input.GetKeyDown(KeyCode.Space) && state == floor){
            isJumping = true;
            player.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
                player.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)) isJumping = false;
    }
}

/*


*/