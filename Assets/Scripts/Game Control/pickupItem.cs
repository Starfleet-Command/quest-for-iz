using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script that generates the pick-upabble items for each playthrough
    Juan Francisco Gortarez
    23/01/2020

*/

public class pickupItem : MonoBehaviour
{

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    Vector3 spawn = new Vector3(0.0f, 0.2f, 0.0f);

    GameObject created;
    private void Awake()
    {
        int itemSel = 999;
        if (PlayerPrefs.GetInt("ItemsSpawned") <= 2) //If less than two items have been spawned in the playthrough
        {
            GameObject[] items = { item1, item2, item3, item4, item5 }; //Possible items that can be spawned by the pool;

            if (PlayerPrefs.GetInt("Progression") <= 7 && PlayerPrefs.GetInt("Progression") >= 2)
            {

                itemSel = Random.Range(0, PlayerPrefs.GetInt("Progression") - 2); //Locks item spawning until after you have killed the boss two times
            }

            else if (PlayerPrefs.GetInt("Progression") > 7)
            {
                itemSel = Random.Range(0, 5);
            }

            if (itemSel != 999)
            {
                GameObject item = items[itemSel];
                setCreated(item);

                Instantiate(item, spawn, Quaternion.Euler(90, 0, 0)); //Select a random item from the pool and spawn it. 
                PlayerPrefs.SetInt("ItemsSpawned", PlayerPrefs.GetInt("ItemsSpawned") + 1);
            }


        }

    }

    GameObject setCreated(GameObject p) //Setter to make the item spawned known to the rest of the code
    {
        created = p;
        return created;
    }




}
