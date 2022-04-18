using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public pumkin_bar bar;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="House"){
            count=bar.getNumber_of_pumkins()+1;
            bar.setAmountNumber(count);
        }
    }
}
