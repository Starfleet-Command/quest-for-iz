/*
 *  Script meant to be used to play the background
 *  music while in the main menu.
 *
 *  Made by:    Daniel Roa
 *       On:    February 4, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance = null;
    public static MusicController Instance
    {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }    
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }   
}
