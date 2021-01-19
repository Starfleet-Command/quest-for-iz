/*
 *  This script will handle the character description menus.
 *  Each one of this panels will hold the class name, the 
 *  character's story, the character's portrait, and two 
 *  buttons, a return and a start quest button.
 *  
 *  Script made on January 20th, 2020 by Daniel Roa and added to on 27/01/2020 by Juan Gortarez
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDescription : MonoBehaviour
{
    //Brawler's main panel
    public GameObject brawlerPanel;
    //Gunner's main panel
    public GameObject gunnerPanel;
    //Wizard's main panel
    public GameObject wizardPanel;

    public GameObject MenuMusic;

    public GameObject infoPanel;
    string showStats;

    void Start()
    {
        MenuMusic = GameObject.Find("MenuMusic");
    }


    //Return to main menu
    public void ReturnCharacterMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameStart()
    {
        //Debug.Log("Game start");
        Destroy(MenuMusic);

        if (PlayerPrefs.GetString("Class") == "Mage")
        {
            PlayerPrefs.SetInt("AtkSpd", 2);
            PlayerPrefs.SetInt("fAtkDmg", 4);
            PlayerPrefs.SetInt("MoveSpd", 3);
            PlayerPrefs.SetInt("sAtkDmg", 3);
            PlayerPrefs.SetInt("HP", 3);
            PlayerPrefs.SetInt("MaxHP", 3);
        }

        else if (PlayerPrefs.GetString("Class") == "Warrior")
        {
            PlayerPrefs.SetInt("AtkSpd", 3);
            PlayerPrefs.SetInt("fAtkDmg", 5);
            PlayerPrefs.SetInt("MoveSpd", 2);
            PlayerPrefs.SetInt("sAtkDmg", 5);
            PlayerPrefs.SetInt("HP", 3);
            PlayerPrefs.SetInt("MaxHP", 3);
        }

        else if (PlayerPrefs.GetString("Class") == "Gunslinger")
        {
            PlayerPrefs.SetInt("AtkSpd", 4);
            PlayerPrefs.SetInt("fAtkDmg", 2);
            PlayerPrefs.SetInt("MoveSpd", 4);
            PlayerPrefs.SetInt("sAtkDmg", 2);
            PlayerPrefs.SetInt("HP", 3);
            PlayerPrefs.SetInt("MaxHP", 3);
        }

        SceneManager.LoadScene("SpawnRoom");

    }

    //Brawler menu start
    public void OpenBrawler()
    {
        if (PlayerPrefs.GetInt("Progression") > 1)
        {
            brawlerPanel.SetActive(true);
            PlayerPrefs.SetString("Class", "Warrior");
        }
    }

    public void CloseBrawler()
    {
        brawlerPanel.SetActive(false);
    }
    //Brawler menu end

    //Gunner menu start
    public void OpenGunner()
    {
        if (PlayerPrefs.GetInt("Progression") >= 0)
        {
            gunnerPanel.SetActive(true);
            PlayerPrefs.SetString("Class", "Gunslinger");
        }

    }

    public void CloseGunner()
    {
        gunnerPanel.SetActive(false);
    }
    //Gunner menu end

    //Wizard menu start
    public void OpenWizard()
    {
        wizardPanel.SetActive(true);
        PlayerPrefs.SetString("Class", "Mage");
    }

    public void CloseWizard()
    {
        wizardPanel.SetActive(false);
    }
    //Wizard menu end
}
