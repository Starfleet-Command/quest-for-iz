using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public int health;
    public int numhearts; 

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Start(){
        health = PlayerPrefs.GetInt("HP");
        numhearts = PlayerPrefs.GetInt("HP");
    }

    void Update()
    {
        health = PlayerPrefs.GetInt("HP");

        if(health>numhearts){
            health = numhearts;
        }

       for(int i =0; i< hearts.Length; i++){

           //Show full or empty hearts
           if(i < health){
               hearts[i].sprite = fullHeart;
           }
           else{
               hearts[i].sprite = emptyHeart;
           }

           //Show array of image hearts depending of maximum hearts
           if(i < numhearts){
               hearts[i].enabled = true;
           }
           else{
               hearts[i].enabled = false ;
           }
       } 
    }
}
