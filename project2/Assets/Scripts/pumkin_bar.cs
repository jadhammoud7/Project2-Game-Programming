using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pumkin_bar : MonoBehaviour
{
    [Tooltip("The slider is the slider of the ammo bar that moves according to the current health of the animal")]
    public Slider slider;


    public Image fill;
    public void setMaxNumber(int pumkin)//set the slider to the max value
    {
        slider.maxValue = pumkin;

    }
    public void setAmountNumber(int pumkin_value)//set the slider to the current value of the pumkin found
    {
        slider.value = pumkin_value;
        Debug.Log("slider is added by 1: "+slider.value);
    }
    void Start()
    {
        
    }
    public int getNumber_of_pumkins(){
        return (int)slider.value;
    }
    public bool hasWOn(){
        if(slider.value==slider.maxValue){
            return true;
        }
        return false;
    }
}