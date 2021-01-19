using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    // Start is called before the first frame update
    public float countdown = 5;
    public float firing = 3;
    public GameObject laser;
    public Material Fire;
    public Material Fire2;
    private bool start = false;
    private bool fire = false;
    public Rigidbody rb;
    public Vector3 pos;
    Renderer rend;

    GameObject laserClone;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            countdown = 15;
            start = true;
        }

        if (start == true)
        {
            laserClone = (GameObject)Instantiate(laser, pos, Quaternion.Euler(90, -45, 0));
            rend = laserClone.GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = Fire2;
            start = false;
            rend.sharedMaterial = Fire;
            fire = true;
            Destroy(laserClone, 3.8f);
        }

        if (fire == true)
        {
            firing -= Time.deltaTime;
        }

        if (firing <= 0)
        {
            rend.sharedMaterial = Fire;
            fire = false;
            firing = 3;

        }

    }
}
