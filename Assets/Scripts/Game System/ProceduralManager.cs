using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int playerXPosition;
    [SerializeField] private int lastWidthPos = -2;
    private ProceduralGeneration tileGenerator;
    // Start is called before the first frame update
    void Start()
    {
        tileGenerator = GetComponent<ProceduralGeneration>();
        lastWidthPos = tileGenerator.GenerateMap(-2, 90, 5, 15, 5);
        player = GameObject.FindGameObjectWithTag("Player");
        playerXPosition = (int)player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - playerXPosition > 30)
        {
            playerXPosition = (int)player.transform.position.x;

            lastWidthPos = tileGenerator.GenerateMap(lastWidthPos, lastWidthPos + 90, 5, 15, 5);
        }
    }
}
