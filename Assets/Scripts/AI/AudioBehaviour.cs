/*
 *  Script that enables the ability to add movement and death sound effects to enemies.
 *
 *  Made by:    Daniel Roa  &   Juan Francisco
 *       On:    January 30, 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehaviour : MonoBehaviour
{
    public AudioClip hallo;
    public AudioClip iDie;
    public AudioSource iMove;

    // Start is called before the first frame update
    void Start()
    {
        iMove.clip = hallo;
        iMove.Play();
    }

    private void OnDestroy()
    {
        iMove.clip = iDie;
        AudioSource.PlayClipAtPoint(iDie, new Vector3(0, 0.2f, 0), 100f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
