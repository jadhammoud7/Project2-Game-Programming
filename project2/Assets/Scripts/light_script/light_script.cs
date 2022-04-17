using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_script : MonoBehaviour
{
    [SerializeField]
    Light mylight;
    float light_current;
    float light_intensity;
    void Start()
    {
        mylight.intensity = 1;
        light_intensity = mylight.intensity;
        light_current = mylight.intensity;
        Debug.Log(mylight.intensity);
        Debug.Log("light intensity is: " + mylight.intensity);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(turnON());

        }
    }
        public void OnTriggerExit(Collider other) {
            if(other.gameObject.tag=="Player"){
                light_intensity=light_current;
                mylight.intensity=light_intensity;
                StopCoroutine(turnON());


            }
        }
     IEnumerator turnON(){
        for(float i=light_intensity;light_intensity<=100;light_intensity+=1f){
            mylight.intensity=light_intensity;
        }
        yield return new WaitForSeconds(1f);//every iteration will take 1 sec
    } 

}
