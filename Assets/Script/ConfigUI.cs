using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigUI : MonoBehaviour
{
    Text main;

    float maxAlpha = 1f;
    float minAlpha = 0f;

    float t = 0f;
    private void Start() {
        main = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        main.color = Color.Lerp(new Color(1,1,1,minAlpha),new Color(1,1,1,maxAlpha),t);

        t += 1 * Time.deltaTime;

        if(t > 1.0f){
            float reversAlpha = maxAlpha;
            maxAlpha = minAlpha;
            minAlpha = reversAlpha;
            t = 0f;
        }
    }
}
