using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterProperties : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D hitBox;
    private GameObject enemy;
    private Animator anim;

    public GameObject platformEnd;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<BoxCollider2D>();
        
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(hitBox, enemy.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(hitBox, platformEnd.transform.GetChild(0).GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(hitBox, platformEnd.transform.GetChild(1).GetComponent<BoxCollider2D>());

    }


    // Update is called once per frame
    void Update()
    {
    }
}
