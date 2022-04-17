using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutine_script : MonoBehaviour
{
    [SerializeField]
    Light light;
    float light_intensity;
    float light_current;
    int x=0;
    // Start is called before the first frame update
    void Start()
    {
        light.intensity=1;
        light_intensity=light.intensity;
        light_current=light.intensity;
        Debug.Log(light.intensity);  
        Debug.Log("light intensity is: "+light.intensity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag=="Player"){
    //         Debug.Log("I am in the house");
    //         while(x<=10){
    //             StartCoroutine(turnON());
    //             StartCoroutine(turnOFF());
    //             x++;

    //         }
    //         }
    //     }
    //     public void OnTriggerExit(Collider other) {
    //         if(other.gameObject.tag=="Player"){
    //             light_intensity=light_current;
    //             light.intensity=light_intensity;
    //             Debug.Log("I am out the house");
    //             StopCoroutine(turnON());
    //             StopCoroutine(turnOFF());


    //         }
    //     }
//  IEnumerator turnON(){
//     for(float i=light_intensity;light_intensity<=100;light_intensity+=1f){
//         light.intensity=light_intensity;
//     }
//     yield return new WaitForSeconds(1f);//every iteration will take 1 sec
// } 
//  IEnumerator turnOFF(){
//     for(float i=light_intensity;light_intensity>=1;light_intensity-=1f){
//         light.intensity=light_intensity;
//     }
//     yield return new WaitForSeconds(1f);//every iteration will take 1 sec
// } 


}
