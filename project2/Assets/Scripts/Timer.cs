using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{


    [SerializeField]
    Image image;
    float fill;
    float current;
    // Start is called before the first frame update
    void Start()
    {
        image.fillAmount = 1;
        fill = image.fillAmount;
        current = image.fillAmount;
        StartCoroutine(turnON());

    }

    // Update is called once per frame
    void Update()
    {
        if (image.fillAmount == 0)
        {
            StopCoroutine(turnON());
        }
    }



    IEnumerator turnON()
    {
        for (float i = fill; fill >= 0; fill -= .1f)
        {
            image.fillAmount = fill;
            yield return new WaitForSeconds(5f);//every iteration will take 1 sec
        }
        image.fillAmount = 0;
        Debug.Log("Amount is now: " + image.fillAmount);
        // yield return new WaitForSeconds(1f);//every iteration will take 1 sec
    }
}
