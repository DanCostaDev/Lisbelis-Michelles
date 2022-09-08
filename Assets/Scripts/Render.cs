using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Render : MonoBehaviour
{
    public TMP_Text text;
    public int score;
    void Start()
    {
        if(PlayerPrefs.HasKey("points")){
            score = PlayerPrefs.GetInt("points");

        } else {
            score = 0;
        }
        text.text = "Maior pontuação: " + score.ToString();
        Debug.Log("teste");
        Debug.Log(PlayerPrefs.GetInt("teste"));
    }

     

    
}
