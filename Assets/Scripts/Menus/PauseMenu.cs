/*
 *  Pause menu controller, is in charge of having the menu working
 *  inside, the settings panel, alongside it's controllers, work correctly.
 *
 *  Made by:    Daniel Roa
 *       On:    January 29, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool gamePaused;

    public GameObject settingsPanel;

    public GameObject BackgroundMusic;

    void Start() 
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitToHome()
    {
        SceneManager.LoadScene(0);
        Destroy(BackgroundMusic);
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting game");
        Application.Quit();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }

        if (gamePaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    public void ContinueButton()
    {
        gamePaused = false;
        Time.timeScale = 1;             //Movement will continue on screen
        pauseMenuUI.SetActive(false);
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;             //No movement on screen
        pauseMenuUI.SetActive(true);
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;             //Movement will continue on screen
        pauseMenuUI.SetActive(false);
    }
}
