/*
 *  This script was made to control the death screen
 *  and it's buttons.
 *
 *  Made by:    Daniel Roa
 *       On:    January 23rd, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        transform.parent.gameObject.GetComponent<Canvas>().enabled = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SpawnRoom");
        this.gameObject.transform.parent.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        this.gameObject.transform.parent.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting");
        Application.Quit();
    }
}
