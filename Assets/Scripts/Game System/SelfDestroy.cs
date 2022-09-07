using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position.x - transform.position.x);
        if ( distance > 120)
        {
            Destroy(gameObject);
        }
    }
}
