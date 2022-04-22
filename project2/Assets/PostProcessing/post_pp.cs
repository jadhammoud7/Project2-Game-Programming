using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class post_pp : MonoBehaviour
{

    private PostProcessVolume volume;
    
    LensDistortion lens;
    // Start is called before the first frame update
    void Start()
    {
        volume=this.GetComponent<PostProcessVolume>();
        lens=ScriptableObject.CreateInstance<LensDistortion>();
        lens.enabled.Override(true);
        volume=PostProcessManager.instance.QuickVolume(gameObject.layer,100f,lens);


    }

    // Update is called once per frame
    void Update()
    {

    // if(Input.GetKey(KeyCode.B)){
    //     lens.intensity.Override(100f);
    // }   
    }

    public  void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            lens.intensity.Override(100f);
        }
    }
        public  void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
            lens.intensity.Override(0f);
        }
    }
        
    
}
