/*
 *  Script that's in charge of monitoring volume levels
 *  once the player is in the game.
 *
 *  Made by:    Daniel Roa
 *       On:    January 29, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameMixer : MonoBehaviour
{
    public AudioMixer inGameMixer;

    public void SetVolume(float volume)
    {
        inGameMixer.SetFloat("GameVolume", volume);
        //Debug.Log(volume);
    }

}
