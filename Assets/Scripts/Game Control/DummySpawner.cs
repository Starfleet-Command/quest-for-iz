using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{

    /*
    Made by: Juan Francisco Gortarez
    On: 05/02/2020
    This script helps playtesting by resetting the EnemiesPresent to 0 on the spawnroom, where no enemies spawn.
    */
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("EnemiesPresent", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
