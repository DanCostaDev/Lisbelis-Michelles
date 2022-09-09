using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public Rigidbody2D player;
    public Points points;
    void Update(){
        
        if(player.position.y < -50){           
            DeadPlayer();
        }
        
    }

    
    public void DeadPlayer(){
        if(PlayerPrefs.HasKey("points")){
            if(PlayerPrefs.GetInt("points") < points.ReturnPoints()){
                PlayerPrefs.SetInt("points", points.ReturnPoints());
            }
        } else {
            PlayerPrefs.SetInt("points", points.ReturnPoints());
        }
        PlayerPrefs.Save();

        SceneManager.LoadScene("Menu");

    }
}
