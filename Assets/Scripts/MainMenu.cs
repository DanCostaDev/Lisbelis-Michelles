using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Level");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay(){
        SceneManager.LoadScene("HowToPlay");
    }
}
