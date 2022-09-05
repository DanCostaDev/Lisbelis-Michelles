using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int playerXPosition;
    private ProceduralGeneration tileGenerator;
    // Start is called before the first frame update
    void Start()
    {
        tileGenerator = GetComponent<ProceduralGeneration>();
        tileGenerator.Generator();
        player = GameObject.FindGameObjectWithTag("Player");
        playerXPosition = (int)player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - playerXPosition > 30)
        {
            playerXPosition = (int)player.transform.position.x;
            tileGenerator.Generator(playerXPosition + 30, playerXPosition + 60, 5, 15, 5);
            
        }
    }
}
