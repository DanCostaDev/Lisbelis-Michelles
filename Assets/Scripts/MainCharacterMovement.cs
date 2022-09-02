using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    float dirX, dirZ, moveSpeed;
    public float moveSpeedBase;
    public float jumpForce;
    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jump = new Vector2(dirX, jumpForce);
            player.AddForce(jump);
            Debug.Log("pulo");
        }
    }
}
