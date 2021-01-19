using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Made by: Juan Francisco Gortarez
    On: January 20th, 2020

    This script spawns the correct asset on the dungeon depending on the class the player selected.
*/


public class PlayerSpawn : MonoBehaviour
{
    GameObject player;
    public Transform playerSpawn;
    public GameObject warrior;
    public GameObject mage;
    public GameObject gunslinger;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetString("Class") == "Mage")
        {
            player = mage;
        }

        else if (PlayerPrefs.GetString("Class") == "Warrior")
        {
            player = warrior;
        }

        else if (PlayerPrefs.GetString("Class") == "Gunslinger")
        {
            player = gunslinger;
        }

        Quaternion playerRotation = Quaternion.Euler(90, 0, 0);
        Instantiate(player, playerSpawn.position, playerRotation);
    }

}
