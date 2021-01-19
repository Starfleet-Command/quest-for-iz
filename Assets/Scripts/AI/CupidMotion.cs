using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Script that sets the motion and interaction of the ranged enemy
    Juan Francisco Gortarez
    23/01/2020

*/

public class CupidMotion : MonoBehaviour
{
    Transform player;
    float angle;
    public GameObject arrow;
    Vector3 movement;

    Vector3 direction;
    bool cooldownActive;
    Rigidbody rb;
    public UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        cooldownActive = false;
        rb = this.gameObject.GetComponent<Rigidbody>();
        direction = new Vector3(90, 0, 0);
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(Cooldown());


    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        movement = transform.forward;

        angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;


        if (!cooldownActive)
        {
            Instantiate(arrow, rb.position, Quaternion.Euler(0, angle, 0));
            StartCoroutine(Cooldown());
        }

    }

    float runningRange = 14.0f;

    void OnCollisionEnter(Collision other) //Makes the enemy run away from the user
    {
        if (other.gameObject.tag == "FastProjectile" || other.gameObject.tag == "SlowProjectile")
        {
            // Set a target location to move to in the direction the player is looking
            Vector3 targetDestination = player.TransformDirection(transform.right)
            + new Vector3(Random.Range(-runningRange, runningRange), 0, Random.Range(-runningRange, runningRange));
            // Use this targetDestination to where you want to move your enemy NavMesh Agent
            agent.SetDestination(targetDestination);
        }



    }

    IEnumerator Cooldown() //Does not allow the enemy to spam ranged attacks
    {
        cooldownActive = true;
        yield return new WaitForSecondsRealtime(5);

        cooldownActive = false;
    }


    //Missing code for shooting arrows

}
