/*
 *  This script is meant for the character selection, therefore
 *  allowing the player to choose and play with their desired
 *  character.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    public void WizardSelect()
    {
        PlayerPrefs.SetInt("AtkSpd", 2);
        PlayerPrefs.SetInt("fAtkDmg", 4);
        PlayerPrefs.SetInt("MoveSpd", 2);
        PlayerPrefs.SetInt("sAtkDmg", 4);
        PlayerPrefs.SetInt("HP", 3);
    }

    public void BrawlerSelect()
    {

        PlayerPrefs.SetInt("AtkSpd", 3);
        PlayerPrefs.SetInt("fAtkDmg", 5);
        PlayerPrefs.SetInt("MoveSpd", 2);
        PlayerPrefs.SetInt("sAtkDmg", 4);
        PlayerPrefs.SetInt("HP", 3);

    }

    public void GunnerSelect()
    {
        PlayerPrefs.SetInt("AtkSpd", 4);
        PlayerPrefs.SetInt("fAtkDmg", 2);
        PlayerPrefs.SetInt("MoveSpd", 4);
        PlayerPrefs.SetInt("sAtkDmg", 2);
        PlayerPrefs.SetInt("HP", 3);
    }

}
