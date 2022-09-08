using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxHealth(int life){
        slider.maxValue = life;
        slider.value = life;
    }

    public void SetHealth(int life){
        slider.value = life;
    }
}
