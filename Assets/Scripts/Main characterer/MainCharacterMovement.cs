using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private GameObject gameManager;
    private GameManager scriptManager;
    private Animator anim;

    public float jumpTime;
    public float jumpForce;
    private bool isJumping;
    public float moveSpeed;
    private float moveInput;
    public Text txtPoints;
    public int points;
    private float previusX;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        scriptManager = gameManager.GetComponent<GameManager>();
        points = 0;
        previusX = player.position.x;
        //state = floor;
    }

    // Update is called once per frame
    void FixedUpdate() {
         
            dirX = Input.GetAxisRaw("Horizontal");
            if(dirX < 0 && !ReturnAnim())
            {
                GetComponent<SpriteRenderer>().flipX = true;
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle") && state == floor && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerJump"))
                {
                    anim.SetBool("isWalking", true);
                }
                
            }
            else if(dirX > 0 && !ReturnAnim())
            {
                GetComponent<SpriteRenderer>().flipX = false;
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle") && state == floor && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerJump"))
                {
                    anim.SetBool("isWalking", true);
                }
            }
            else if(dirX == 0)  
            {
                anim.SetBool("isWalking", false);
            }
            if (!ReturnAnim())
            {
                moveSpeed = moveSpeedBase;
                Vector2 movement = new Vector2(dirX * moveSpeed * scriptManager.GetKarma(), player.velocity.y);
                player.velocity = movement;
            }
          
    }
    
    void Update(){
        KeyInputs();
        countPoints();
    }
    private void OnCollisionStay2D(Collision2D other) {
        
        if(other.gameObject.tag == "Ground" && player.velocity.y < 1 && player.velocity.y > -1 ) {
            state = floor;
            anim.SetBool("isJumping", false);
            anim.SetFloat("speedMultiplier", 1000f);
            
            
        }
    }   

    private void OnCollisionExit2D(Collision2D other) {
        //if(state == floor){
            if(other.gameObject.tag == "Ground") {
                state = air;
                anim.SetFloat("speedMultiplier", 1f);
                anim.SetBool("isJumping", true);
                //Debug.Log("EXIT"); 
            }
        //}
    }

    private void KeyInputs(){
        if(Input.GetKeyDown(KeyCode.Space) && state == floor){
            if (!ReturnAnim())
            {
                isJumping = true;
                state = air;
                anim.SetBool("isWalking", false);
                anim.SetBool("isJumping", true);
                //anim.SetTrigger("Jump");
                player.velocity = Vector2.up * jumpForce;
                jumpTimeCounter = jumpTime;
            }
            
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

    private bool ReturnAnim()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerDamage"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void countPoints(){
        float x;
        if(player.position.x > previusX){
            previusX = player.position.x;
            x = previusX / 10;
            points = (int) x;
            txtPoints.text = "Pontos: " + points.ToString();
        }
        
    }
}
