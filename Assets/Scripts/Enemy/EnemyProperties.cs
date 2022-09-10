using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    private GameObject player;
    public Transform collisionPoint;
    [SerializeField] private int health = 2;
    [SerializeField] private float collisionRange = 2.2f;
    [SerializeField] private Collider2D[] colliderPlayer;
    [SerializeField] Vector2 force;

    private float attackRate = 1f;
    private float nextAttackTime = 0f;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collisionPoint = GetComponentInChildren<Transform>();
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>(), true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - gameObject.transform.position.x >= 80)
        {
            Destroy(gameObject);
        }

        if(Time.time > nextAttackTime) {
        }
        colliderPlayer = Physics2D.OverlapCircleAll(collisionPoint.position, collisionRange);

        foreach (Collider2D playerCollider in colliderPlayer)
        {
            if(playerCollider.gameObject.tag == "Player" && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SkeletonDeath"))
            {
                if (Time.time > nextAttackTime)
                {
                    Vector2 difference = (playerCollider.transform.position - gameObject.transform.GetChild(0).transform.position).normalized;
                    if(difference.x < 0)
                    {
                        force = new Vector2(-1, 1);
                    }
                    else
                    {
                        force = new Vector2(1, 1);
                    }

                    Debug.Log("player entrou = " + difference + " " + force);
                    player.GetComponent<MainCharacterProperties>().TakeDamage(1, force);
                    nextAttackTime = Time.time + 2f / (attackRate);
                }                
            }
        }
    }

    public void TakeDamage(int value)
    {
        GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<Animator>().SetTrigger("Damage");
        Vector2 difference = (gameObject.transform.GetChild(0).transform.position - player.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1500, 100) * difference);
        health -= value;
        if(health == 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(collisionPoint.position, collisionRange);
    }
}
