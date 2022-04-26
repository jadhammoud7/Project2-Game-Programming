using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//fir canvas
using UnityEngine.SceneManagement;// to load to another scene
using TMPro;

public class Timer : MonoBehaviour
{
    [Tooltip("The canvas displaying that the player has won")]
    [SerializeField] GameObject haswon;
    [Tooltip("The text that shows the final score by the player")]
    [SerializeField] TextMeshProUGUI score_text_final;
    [Tooltip("The canvas displaying that the player has lost")]
    [SerializeField] GameObject haslost;
    [Tooltip("The image which is the timer circle displaying the time passed and remaining for the game to finish")]
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

        if (getTimer() > 0 && amount_of_pumpkin.hasWOn())//if all pumpkins collected and before time runs out
        {
            haswon.SetActive(true);//display won canvas
            Time.timeScale = 0f;//pause game
            if (Input.GetKeyDown(KeyCode.N))// move to level 2
            {
                SceneManager.LoadScene(2);
            }
            //canvas won
            //press key to move to next page
        }
        if (getTimer() == 0 && !amount_of_pumpkin.hasWOn())//if times run out and not all pumpkins are collected
        {
            //canvas lost
            haslost.SetActive(true);//display lost canvas
            Time.timeScale = 0f; //pause time of the game
            score_text_final.text="You collected "+amount_of_pumpkin.getNumber_of_pumkins()+" /12 pumkpins only";
            if (Input.GetKeyDown(KeyCode.K)) //play again
            {
                SceneManager.LoadScene(1);// load the same screen
            }

        }
    }



    IEnumerator turnON()
    {
        for (float i = fill; fill >= 0; fill -= .1f)//every 5 sec decrement timer by 0.1
        {
            image.fillAmount = fill;
            yield return new WaitForSeconds(5f);//every iteration will take 5 sec
        }
        image.fillAmount = 0;
        Debug.Log("Amount is now: " + image.fillAmount);
        // yield return new WaitForSeconds(1f);//every iteration will take 1 sec
    }
    public float getTimer()
    {
        return image.fillAmount;
    }
    public void PlayAgain(){
        SceneManager.LoadScene(1);// load the same screen

    }
    public void NextLevel(){
        SceneManager.LoadScene(2);

    }
}
