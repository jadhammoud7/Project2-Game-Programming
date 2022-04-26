using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsScriptWithPooling : MonoBehaviour
{
    GameObject BatsFactory;
    BatsFactoryWithPooling BFWithPooling;
    // Start is called before the first frame update
    void Start()
    {
        BatsFactory = GameObject.Find("BatsFactory");
        BFWithPooling = BatsFactory.GetComponent<BatsFactoryWithPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onTriggerEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            StartCoroutine(BFWithPooling.addToPool(this.gameObject));
        }
    }
}