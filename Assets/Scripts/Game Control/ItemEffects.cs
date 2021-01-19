using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script attached to the items that applies their effects to the player
    Juan Francisco Gortarez
    23/01/2020

*/

public class ItemEffects : MonoBehaviour
{
    public string[] statGain;
    public string statLoss;
    GameObject statPopup;

    private void Start()
    {
        statPopup = GameObject.Find("Stats");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            //Applies the relevant effects on player stats depending on item type
            PlayerPrefs.SetInt(statGain[0], PlayerPrefs.GetInt(statGain[0]) + 1);
            PlayerPrefs.SetInt(statLoss, PlayerPrefs.GetInt(statLoss) - 1);

            statPopup.transform.GetChild(0).GetComponent<StatsScreen>().CreateText(statGain[0], statLoss);

        }
    }
}
