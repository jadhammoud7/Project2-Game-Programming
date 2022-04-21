using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//fir canvas
using UnityEngine.SceneManagement;// to load to another scene
using TMPro;

public class Timer_Scene2 : MonoBehaviour
{
    [SerializeField] GameObject haswon;

    [SerializeField] TextMeshProUGUI score_text_final;

    [SerializeField] GameObject haslost;
    [SerializeField] GameObject hasdied;
    [SerializeField]
    Image image;
    float fill;
    float current;
    public pumkin_bar amount_of_pumpkin;
    public health_bar amount_of_health; //this is for comparing the time and health for either winning or losing the game

    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = 1;
        fill = image.fillAmount;
        current = image.fillAmount;
        StartCoroutine(turnON());

    }

    // Update is called once per frame
    void Update()
    {
        if (image.fillAmount == 0)
        {
            StopCoroutine(turnON());
        }

        if (getTimer() > 0 && amount_of_pumpkin.hasWOn())
        {
            haswon.SetActive(true);
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.N))// move to level 2
            {
                SceneManager.LoadScene(2);
            }
            //canvas won
            //press key to move to next page
        }
        if (getTimer() == 0 && !amount_of_pumpkin.hasWOn() && amount_of_health.getNumber_of_health() > 0)
        {
            //canvas lost
            haslost.SetActive(true);
            Time.timeScale = 0f; //pause time of the game
            score_text_final.text = "You collected " + amount_of_pumpkin.getNumber_of_pumkins() + " /12 pumkpins only";
            if (Input.GetKeyDown(KeyCode.K)) //play again
            {
                SceneManager.LoadScene(2);// load the same screen
            }

        }
        if (getTimer() > 0 && amount_of_health.getNumber_of_health() == 0)
        {//when health is 0
            //died
            Debug.Log(amount_of_health.getNumber_of_health() + " is my health");
            hasdied.SetActive(true);
            Time.timeScale = 0f; //pause time of the game
            if (Input.GetKeyDown(KeyCode.K)) //play again
            {
                SceneManager.LoadScene(2);// load the same screen
            }
        }

        if (getTimer() == 0 && amount_of_health.getNumber_of_health() == 0)
        {//when health is 0
            //lost
            haslost.SetActive(true);
            Time.timeScale = 0f; //pause time of the game
            if (Input.GetKeyDown(KeyCode.K)) //play again
            {
                SceneManager.LoadScene(2);// load the same screen
            }
        }
    }



    IEnumerator turnON()
    {
        for (float i = fill; fill >= 0; fill -= .1f)
        {
            image.fillAmount = fill;
            yield return new WaitForSeconds(5f);//every iteration will take 1 sec
        }
        image.fillAmount = 0;
        Debug.Log("Amount is now: " + image.fillAmount);
        // yield return new WaitForSeconds(1f);//every iteration will take 1 sec
    }
    public float getTimer()
    {
        return image.fillAmount;
    }
}