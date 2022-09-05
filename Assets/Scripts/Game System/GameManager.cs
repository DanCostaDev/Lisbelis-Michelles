using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float karma = 1f;
    private Image karmaBar;
    // Start is called before the first frame update
    void Start()
    {
        karmaBar = GameObject.FindGameObjectWithTag("KarmaBar").GetComponent<Image>();
        karmaBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetKarma()
    {
        return karma;
    }

    public void increaseKarma(float value)
    {
        if(karma < 5f)
        {
            karma += value;
            karma = Mathf.Clamp(karma, 1, 5f);
            karmaBar.fillAmount = karma / 5f;
        }
    }
}
