/*
    Script to push a ball around

    Juanfra 14/01/2020
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ball : MonoBehaviour
{
    Vector3 motion;

    Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Get directions from user
        motion.x = Input.GetAxis("Horizontal");
        motion.z = Input.GetAxis("Vertical");

        //Apply direct translation to the object
       rb.velocity = motion* speed;
    }
}
