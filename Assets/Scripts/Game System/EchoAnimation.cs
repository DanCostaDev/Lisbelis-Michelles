using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoAnimation : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerJump") && gameObject.activeSelf)
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }
    }
}
