/*
 *  Script meant to be used to stop the background
 *  music while in the player is transfered to the game screen.
 *
 *  Made by:    Daniel Roa
 *       On:    February 4, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
