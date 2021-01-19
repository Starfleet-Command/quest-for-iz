using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script that handles spawning when there are multiple directions the spawn could be, depending on room last visited
    Juan Francisco Gortarez
    23/01/2020

*/

public class CenterPlayerSpawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Vector4 limits;
    private Vector3 spawn;

    GameObject player;
    public GameObject warrior;
    public GameObject mage;
    public GameObject gunslinger;

    public Transform westSpawn;
    public Transform eastSpawn;

    public Transform southSpawn;

    public Transform bossSpawn;
    // Execute as soon as the scene is created

    void Start()
    {
        /* Positions as: 
        X: Top
        Y: Bottom
        Z: Left
        W: Right
    */

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

        //Spawns player on the correct position depending where they came from
        switch (PlayerPrefs.GetInt("PrevLevel"))
        {
            case 2:
                Instantiate(player, westSpawn.position, playerRotation);
                break;

            case 4:
                Instantiate(player, eastSpawn.position, playerRotation);
                break;

            case 5:
                Instantiate(player, southSpawn.position, playerRotation);
                break;

            case 6:
                Instantiate(player, bossSpawn.position, playerRotation);
                break;

            default:
                Instantiate(player, westSpawn.position, playerRotation);
                break;
        }

        GameObject[] enemies = { enemy1, enemy2, enemy3 };
        int enemyNumber = Random.Range(1, 4);
        PlayerPrefs.SetInt("EnemiesPresent", enemyNumber);



        //Generate the enemies from a random pool in a random place inside the map
        for (int r = 0; r < enemyNumber; r++)
        {
            spawn.x = Random.Range(limits.x, limits.y);
            spawn.y = 0.2f;
            spawn.z = Random.Range(limits.z, limits.w);

            int enemyType = Random.Range(0, 2);
            Instantiate(enemies[enemyType], spawn, Quaternion.identity);


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
