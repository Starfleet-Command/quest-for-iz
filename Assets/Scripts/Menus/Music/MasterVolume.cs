/*
 *  Script meant to lower the volume of the main menu.
 *  
 *  Made on: 21/01/2020  
 *  Made by: Daniel Roa
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterVolume : MonoBehaviour
{
    
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MasterVolume", volume);
    }

}
