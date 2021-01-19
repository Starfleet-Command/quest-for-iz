/*
 *  Script meant to be used to stop the background
 *  music while in the player is transfered to the boss screen.
 *
 *  Made by:    Daniel Roa
 *       On:    February 4, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDungeonMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InGameMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
