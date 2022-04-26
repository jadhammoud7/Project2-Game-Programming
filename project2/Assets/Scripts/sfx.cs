using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10)){
            if(hit.collider.gameObject.tag == "Slender"){//when the raycast from player hits a slender
                GameObject slender = hit.collider.gameObject;//the slender which is hit
                slender.GetComponent<AudioSource>().Play();//play the sound of the slender
                Debug.Log("Slender is making sound");
            }    
        }
        
    }
    public void OnCollisionEnter(Collision other) {//when player collides with object of tag spooky
        if(other.gameObject.tag=="spooky"){
            other.gameObject.GetComponent<AudioSource>().Play();//play sound of game object
       }
    }
}
