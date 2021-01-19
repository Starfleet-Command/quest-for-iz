using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotionM1 : MonoBehaviour
{

    public float speed;
    public GameObject bullet;
    public GameObject explosion;


    void Start(){
        this.GetComponent<AudioSource>().Play();
        Destroy(bullet, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss")
        {
            GameObject Explosion_Clone = (GameObject)Instantiate(explosion, this.gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(this.gameObject); 
            Destroy(Explosion_Clone, 0.4f);
        }
    }
}
