using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns;

    public GameObject echo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle"))
        {
            if(timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, new Vector3 (transform.position.x, transform.position.y, 5f), Quaternion.identity);
                if(GetComponent<SpriteRenderer>().flipX == true)
                {
                    instance.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    instance.GetComponent<SpriteRenderer>().flipX = false;
                }

                Destroy(instance, 0.5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
