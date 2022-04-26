using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    [Tooltip("The score script of the player")]
    public score getscore;
    [Tooltip("The pumpkin bar that will display the number of pumpkins collected compared to total as a bar")]
    public pumkin_bar bar;
    [Tooltip("The health bar of the player that will decrease by 10 when hit by the enemy")]
    public health_bar health_Bar;
    int count = 0;
    int health = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pumpkin")//when player collides with pumpkin
        {
            Debug.Log("i got a pumpkin");
            count = getscore.getScore();
            bar.setAmountNumber(count);//increase the slider value of the pumpkin bar by 1
        }
        if (other.gameObject.tag == "Slender")//when the player is hit by the slender enemy
        {
            health=health_Bar.getNumber_of_health()-10;//decrease health bar by 10
            health_Bar.setAmountNumber(health);
            other.gameObject.GetComponent<Animator>().SetBool("attack", true);
            Debug.Log("Slender is attacking you!");
        }
    }
}
