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
            if(hit.collider.gameObject.tag == "Slender"){
                GameObject slender = hit.collider.gameObject;
                slender.GetComponent<AudioSource>().Play();
                Debug.Log("Slender is making sound");
            }    
        }
        
    }
    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="spooky"){
            other.gameObject.GetComponent<AudioSource>().Play();
       }
    }
}
