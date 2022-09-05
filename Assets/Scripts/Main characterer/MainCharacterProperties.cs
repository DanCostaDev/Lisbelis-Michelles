using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterProperties : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D hitBox;
    private GameObject enemy;
    private Animator anim;

    [SerializeField] private GameObject inimigo;

    //public GameObject platformEnd;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        //if(enemy != null)
        //{
        //    Physics2D.IgnoreCollision(hitBox, enemy.GetComponent<BoxCollider2D>());
        //}
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int value, Vector2 knockBack)
    {
        GetComponent<Rigidbody2D>().AddForce(knockBack, ForceMode2D.Force);
        GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<Animator>().SetTrigger("Damage");
    }

}
