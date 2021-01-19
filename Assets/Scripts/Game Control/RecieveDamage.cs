using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar healthBar;
    public GameObject IcicleExplosion;
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col) //This causes the boss to take damage depending on the attack and the damage stat of each attack
    {
        if (col.gameObject.tag == "FastProjectile")
        {
        
            healthBar.TakeDamage(PlayerPrefs.GetInt("fAtkDmg") * 10);
            //GameObject IcicleExplosion_Clone = (GameObject)Instantiate(IcicleExplosion, col.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            //Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SlowProjectile")
        {
            
            healthBar.TakeDamage(PlayerPrefs.GetInt("sAtkDmg") * 45);
            //Destroy(col.gameObject);
        }

    }
}
