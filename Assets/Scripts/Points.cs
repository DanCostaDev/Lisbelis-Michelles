using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public Rigidbody2D player;

    public Text txtPoints;
    public int points;
    private float previusX;
    
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody2D>();
         points = 0;
         previusX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        countPoints();
    }
    private void countPoints(){
        float x;
        if(player.position.x > previusX){
            previusX = player.position.x;
            x = previusX / 10;
            points = (int) x;
            txtPoints.text = "Pontos: " + points.ToString();
        }
        
    }

    public int ReturnPoints(){
        return points;
    }
}
