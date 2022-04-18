using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour

{
    [SerializeField] pumpkinSO thisPumpkin;
    [SerializeField] score currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore.Overllscore=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void OnTriggerEnter(Collider other) {
    if(other.gameObject.name=="Player"){
        currentScore.Overllscore+=thisPumpkin.pumpkinWeight;
        Debug.Log("Score is now: "+currentScore.Overllscore);
        Destroy(gameObject);
    }
}
}
