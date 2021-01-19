using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombColorChange : MonoBehaviour
{
    float duration = 3.8f;
    private float t = 0;

    // Update is called once per frame
    void Update()
    {
        ColorChanger();
    }

    void ColorChanger(){

        Renderer rend = this.GetComponent<Renderer>();
        rend.material.color = Color.Lerp(Color.white, Color.red, t);

        if (t < 1){ 
            t += Time.deltaTime/duration;
        }
             
             
     }
}
