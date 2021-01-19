/*
 *  Script that will run after the end screen,
 *  after the final boss is defeated.
 *
 *  Made by:    Daniel Roa
 *       On:    January 28, 2020
 *  Modified by: Juan Francisco
 *       On:    January 29, 2020
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryScreen;
    public Vector3 position;



    public void OnWin()
    {
        Instantiate(victoryScreen, position, Quaternion.identity);
        //TODO: Add victory sounds. 
    }
    public void MainMenu()
    {
        PlayerPrefs.SetInt("Progression", PlayerPrefs.GetInt("Progression") + 1);
        PlayerPrefs.SetInt("ItemsSpawned", 0);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Progression", PlayerPrefs.GetInt("Progression") + 1);
        PlayerPrefs.SetInt("ItemsSpawned", 0);
        Debug.Log("Quitting");
        Application.Quit();
    }
}
