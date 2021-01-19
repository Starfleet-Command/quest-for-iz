using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnoopBulletHell : MonoBehaviour
{

    public GameObject Bullet;
    public float angle = 0;
    public float stepangle;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(ShootBullets()); 
    }

    IEnumerator ShootBullets(){
        if (angle>90){
            angle = 0;
        }
        for(int i = 0; i < 4; i++){
            GameObject BulletClone = (GameObject)Instantiate(Bullet, this.transform.position, Quaternion.Euler(0,i*90+angle,0));
            BulletClone.tag = "BulletHell";
        }
        angle += stepangle;
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ShootBullets());

    }
}
