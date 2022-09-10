using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float karma = 1f;
    [SerializeField] private float maxKarma;
    //private Image karmaBar;
    public KarmaBar karmaBar;
    // Start is called before the first frame update
    void Start()
    {
        // karmaBar = GameObject.FindGameObjectWithTag("KarmaBar").GetComponent<Image>();
            //karmaBar.fillAmount = 0f;
            int max = (int) maxKarma;
            karmaBar.SetMaxKarma(max);
    }

    // Update is called once per frame
    void Update()
    {
        //increaseKarma(0.001f);
    }

    public float GetKarma()
    {
        return karma;
    }
    public float GetMaxKarma(){
        return maxKarma;
    }

    public void increaseKarma(float value)
    {
        int karmaInt;
        if(karma <= maxKarma)
        {
            karma += value;
            karma = Mathf.Clamp(karma, 1, maxKarma);
            karmaInt = (int) karma;
            //karmaBar.fillAmount = karma / 5f;
            karmaBar.SetKarma(karmaInt);
        }
    }
}
