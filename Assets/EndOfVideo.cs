using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndOfVideo : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;
    void Start()
    {
        video.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer video)
    {
        SceneManager.LoadScene("Menu");
    }
}
