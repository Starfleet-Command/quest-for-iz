/*
 *  Script meant to manage the Stats screen.
 *
 *  Made by:    Daniel Roa and Juan Francisco
 *       On:    February 5, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour
{

    public GameObject statsPanel;
    string ShowChange;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject.transform.parent.gameObject);
    }

    public void CreateText(string statUp, string statDown)
    {
        Time.timeScale = 0;
        ShowChange = "" + statUp + " has increased by 1. \n " + statDown + " has decreased by 1.";
        gameObject.transform.parent.GetChild(3).GetComponent<Text>().text = ShowChange;
        transform.parent.gameObject.GetComponent<Canvas>().enabled = true;

    }



    public void CloseStats()
    {
        Time.timeScale = 1;             //movement continues
        statsPanel.SetActive(false);    //Panel disappears
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
