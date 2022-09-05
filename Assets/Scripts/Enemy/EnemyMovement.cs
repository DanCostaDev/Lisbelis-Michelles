using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player;
    public float nearDistance;
    public float farDistance;

    private Animator anim;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlatformEnd")
        {
            direction *= -1;
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < farDistance && Vector3.Distance(transform.position, player.transform.position) > nearDistance)
        {
            if(player.transform.position.x < transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            anim.SetBool("isWalking", true);
            Vector2 movement = new Vector2(player.transform.position.x, 0f);
            transform.position = Vector2.MoveTowards(transform.position, movement, moveSpeed * Time.deltaTime);

            //Vector3 movement = new Vector3(moveSpeed * direction, 0f, 0f);
            //transform.position += movement * Time.deltaTime * moveSpeed;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        

    }
}
