using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar : MonoBehaviour
{
    [Tooltip("The slider is the slider of the ammo bar that moves according to the current health of the animal")]
    public Slider slider;

    [Tooltip("The fill which is the image of the health bar")]
    public Image fill;
    public void setMaxNumber(int health)//set the slider to the max value
    {
        slider.maxValue = health;

    }
    public void setAmountNumber(int health_value)
    {
        slider.value = health_value;
        Debug.Log(" health slider is subtracted by 1: "+slider.value);
    }
    void Start()
    {
        
    }
    public int getNumber_of_health(){
        return (int)slider.value;
    }

}