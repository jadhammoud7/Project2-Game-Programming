using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//for canvas
using UnityEngine.SceneManagement;// to load to another scene
using TMPro;

public class Timer_Scene2 : MonoBehaviour
{
    [Tooltip("The canvas displaying that the player has won")]
    [SerializeField] GameObject haswon;
    [Tooltip("The text that shows the final score by the player")]
    [SerializeField] TextMeshProUGUI score_text_final;
    [Tooltip("The canvas displaying that the player has lost")]
    [SerializeField] GameObject haslost;
    [Tooltip("The canvas displaying that the player was died by the slender enemy")]
    [SerializeField] GameObject hasdied;
    [Tooltip("The image which is the timer circle displaying the time passed and remaining for the game to finish")]
    [SerializeField] Image image;
    float fill;
    float current;
    public pumkin_bar amount_of_pumpkin;//this is the pumpkin bar displaying total pumpkins collected
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
        if (image.fillAmount == 0)//if time is run out
        {
            StopCoroutine(turnON());//stop coroutine of the timer
        }

        if (getTimer() > 0 && amount_of_pumpkin.hasWOn())//if the time is greater than 0 and all pumpkins collected
        {
            haswon.SetActive(true);//display win canvas
            Time.timeScale = 0f;//game paused
            if (Input.GetKeyDown(KeyCode.N))// move to level 2
            {
                SceneManager.LoadScene(2);
            }
            //canvas won
            //press key to move to next page
        }
        if (getTimer() == 0 && !amount_of_pumpkin.hasWOn() && amount_of_health.getNumber_of_health() > 0)// if time ran out, not all pumpkins are collected, and health of player is greater than 0
        {//user loses
            //canvas lost
            haslost.SetActive(true);
            Time.timeScale = 0f; //pause time of the game
            score_text_final.text = "You collected " + amount_of_pumpkin.getNumber_of_pumkins() + " /12 pumkpins only";//set score text
            if (Input.GetKeyDown(KeyCode.K)) //play again
            {
                SceneManager.LoadScene(2);// load the same screen
            }

        }
        if (getTimer() > 0 && amount_of_health.getNumber_of_health() == 0)
        {//when health is 0
            //died
            Debug.Log(amount_of_health.getNumber_of_health() + " is my health");
            hasdied.SetActive(true);//display lost canvas
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



    IEnumerator turnON()//turn on coroutine
    {
        for (float i = fill; fill >= 0; fill -= .1f)//decrement the timer by 0.1 every 5 seconds
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
        public float setTimer(float time)
    {
        return image.fillAmount=time;
    }

    public void restartGame(){
        SceneManager.LoadScene(2);// load the same screen

    }
    public void gotomainmenu(){
        SceneManager.LoadScene(0);// load the same screen
    }

}
