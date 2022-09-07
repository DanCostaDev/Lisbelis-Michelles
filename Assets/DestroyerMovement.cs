using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
