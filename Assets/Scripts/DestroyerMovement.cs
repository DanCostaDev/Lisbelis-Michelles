using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float maxSpeed = 25f;
    [SerializeField] public float movementSpeed = 5.0f;

    // New variables :
    public float accelerationTime = 60;
    private float minSpeed;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        minSpeed = currentSpeed;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, currentSpeed * Time.deltaTime);
        //transform.position -= transform.forward * currentSpeed * Time.deltaTime;
        time += Time.deltaTime;

        
        
    }
}
