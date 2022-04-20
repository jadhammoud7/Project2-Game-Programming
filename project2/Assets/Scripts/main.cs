using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public score getscore;
    public pumkin_bar bar;

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
        if (other.gameObject.tag == "Pumpkin")
        {
            Debug.Log("i got a pumpkin");
            count = getscore.getScore();
            Debug.Log("incremented by 1");
            bar.setAmountNumber(count);
        }
        if (other.gameObject.tag == "Slender")
        {
            health=health_Bar.getNumber_of_health()-10;
            // Debug.Log("Health is now: "+health);
            health_Bar.setAmountNumber(health);
        }
    }
}
