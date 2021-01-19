using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script that handles the player losing life and dying
    Juan Francisco Gortarez
    23/01/2020

*/



public class playerHealth : MonoBehaviour
{
    public GameObject deathScreen;

    public AudioSource playerSounds;
    public AudioClip onHit;

    public AudioClip onDeath;

    private void Start()
    {
        deathScreen = GameObject.Find("DeathScreen");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        playerSounds = GetComponent<AudioSource>();
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("OUCH!");
            playerSounds.clip = onHit;
            playerSounds.Play();
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("HP") - 1);
        }

        if (PlayerPrefs.GetInt("HP") <= 0)
        {
            Debug.Log("You died!");
            playerSounds.clip = onDeath;
            playerSounds.Play();
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("ItemsSpawned", 0);
            deathScreen.gameObject.GetComponent<Canvas>().enabled = true;
            PlayerPrefs.SetInt("HP", 3);
            //Add death animations
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Boss")
        {
            Debug.Log("OUCH!");
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("HP") - 1);
        }


        if (PlayerPrefs.GetInt("HP") <= 0)
        {
            playerSounds.clip = onDeath;
            playerSounds.Play();
            PlayerPrefs.SetInt("ItemsSpawned", 0);
            PlayerPrefs.SetInt("HP", 3);
            Destroy(this.gameObject);
            deathScreen.gameObject.GetComponent<Canvas>().enabled = true;
            //Add death animations
        }
    }
    private void Update()
    {
        //Add code that displays and removes hearts
    }

}
