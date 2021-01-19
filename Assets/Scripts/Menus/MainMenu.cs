/*
 *  Script that runs the main menu
 *
 *  Important information:  
 *
 *  0 - Main Menu
 *  1 - CharacterSelect
 *  4 - Credits
 *
 *  Made by:    Daniel Roa
 *       On:    January 23rd, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public GameObject MainMenuMusic;

    void Start() 
    {
        MainMenuMusic = GameObject.Find("MenuMusic");    
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
      settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        //Debug.Log("Quitting");
        Application.Quit();
    }

}
