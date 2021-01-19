using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int health;
    public int numhearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Material RecievedDamageMat;

    bool recievedDamage = false;

    private void Start()
    {
        deathScreen = GameObject.Find("DeathScreen");
        health = PlayerPrefs.GetInt("HP");
        numhearts = PlayerPrefs.GetInt("MaxHP");
    }

    private void OnCollisionEnter(Collision other)
    {
        playerSounds = GetComponent<AudioSource>();
        if (other.gameObject.tag == "Enemy")
        {

            playerSounds.clip = onHit;
            playerSounds.Play();
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("HP") - 1);
        }

        if (PlayerPrefs.GetInt("HP") <= 0)
        {

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
        if ((col.gameObject.name == "Boss" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "BulletHell" || col.gameObject.tag == "Explosion" || col.gameObject.tag == "LaserDamage") && (recievedDamage == false))
        {
            StartCoroutine(RecieveDamageAgain());
            playerSounds.clip = onHit;
            playerSounds.Play();
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
    void Update()
    {
        health = PlayerPrefs.GetInt("HP");

        if (health > numhearts)
        {
            health = numhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            //Show full or empty hearts
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Show array of image hearts depending of maximum hearts
            if (i < numhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    IEnumerator RecieveDamageAgain()
    {
        recievedDamage = true;
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        recievedDamage = false;
    }

}
