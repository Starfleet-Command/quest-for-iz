using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Script that monitors and manages the enemies' health
    Juan Francisco Gortarez
    23/01/2020

*/


public class EnemyHealth : MonoBehaviour
{
    public int health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FastProjectile")
        {

            health = health - (PlayerPrefs.GetInt("fAtkDmg") * 10);

        }

        else if (other.gameObject.tag == "SlowProjectile")
        {
            health = health - (PlayerPrefs.GetInt("sAtkDmg") * 35);
        }

        if (health <= 0)
        {
            PlayerPrefs.SetInt("EnemiesPresent", PlayerPrefs.GetInt("EnemiesPresent") - 1);
            Destroy(this.gameObject);

        }
    }
}
