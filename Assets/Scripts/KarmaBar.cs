using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarmaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxKarma(int karma){
        slider.maxValue = karma;
        slider.value = karma;
    }

    public void SetKarma(int karma){
        slider.value = karma;
    }
}
