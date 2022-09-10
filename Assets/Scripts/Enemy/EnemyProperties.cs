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
            if(playerCollider.gameObject.tag == "Player")
            {
                if (Time.time > nextAttackTime)
                {
                    Vector2 difference = (playerCollider.transform.position - gameObject.transform.GetChild(0).transform.position).normalized;
                    Vector2 force = difference * 50f;
                    Debug.Log("player entrou");
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
        GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 1));
        health -= value;
        if(health == 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
            Death();
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
