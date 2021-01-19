using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script for the GameController which spawns enemies at random locations in the room, as well as spawns the player in
    Juan Francisco Gortarez
    23/01/2020

*/

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public Vector4 limits;
    private Vector3 spawn;

    // Execute as soon as the scene is created

    void Start()
    {
        /* Positions as: 
        X: Top
        Y: Bottom
        Z: Left
        W: Right
    */



        GameObject[] enemies = { enemy1, enemy2, enemy3 };
        int enemyNumber = Random.Range(1, 4);
        PlayerPrefs.SetInt("EnemiesPresent", enemyNumber);
        Quaternion playerRotation = Quaternion.Euler(90, 0, 0);
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
