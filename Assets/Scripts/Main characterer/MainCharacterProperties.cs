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
    [SerializeField] private GameManager scriptManager;

    //public GameObject platformEnd;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        scriptManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        scriptManager.increaseKarma(-1 * scriptManager.karma);
        GetComponent<Rigidbody2D>().AddForce(knockBack * new Vector2(1200, 1));
        GetComponent<Animator>().SetBool("isWalking", false);
        GetComponent<Animator>().SetTrigger("Damage");
        
    }

}
