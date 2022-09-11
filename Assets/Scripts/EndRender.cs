using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EndRender : MonoBehaviour
{
    public TMP_Text text;
    public int score;
    void Start()
    {
        if(PlayerPrefs.HasKey("lastPoints")){
            score = PlayerPrefs.GetInt("lastPoints");

        } else {
            score = 0;
        }
        text.text = "Sua pontuação foi: " + score.ToString();
    }

     

    
}

