using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Script that changes the scene (room) after going through a door
    Juan Francisco Gortarez
    23/01/2020

*/

public class ChangeRoom : MonoBehaviour
{
    public string nextRoom;
    int enemiesRemaining;


    private void Update()
    {
        enemiesRemaining = PlayerPrefs.GetInt("EnemiesPresent");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && enemiesRemaining <= 0)
        {

            PlayerPrefs.SetInt("PrevLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(nextRoom, LoadSceneMode.Single);
        }
    }
}
