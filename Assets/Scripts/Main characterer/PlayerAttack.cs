using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private GameObject gameManager;
    private GameManager scriptManager;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    public Transform attackPointRight;
    public Transform attackPointLeft;
    public LayerMask enemyLayers;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        scriptManager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerDamage"))
                {                    
                    Attack();
                    nextAttackTime = Time.time + 1f / (attackRate + scriptManager.GetKarma());
                }
            }
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies;
        anim.SetBool("isJumping", false);
        anim.SetBool("isWalking", false);
        anim.SetTrigger("Attack");
        if (GetComponent<SpriteRenderer>().flipX)
        {
            hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        }
        else
        {
            hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        }
        

        foreach(Collider2D enemy in hitEnemies)
        {
            scriptManager.increaseKarma(0.1f);
            enemy.GetComponent<EnemyProperties>().TakeDamage(1);
            Debug.Log("Hit enemy");
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPointRight == null)
            return;
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }
}
