using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("HP", PlayerPrefs.GetInt("HP") - 1);
            Destroy(this.gameObject);
        }
    }
}
