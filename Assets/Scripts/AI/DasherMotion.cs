using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    Script that sets the motion and interaction of the dashing enemy
    Juan Francisco Gortarez
    23/01/2020

*/

public class DasherMotion : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    private float timer;
    Vector3 direction;
    Transform child;



    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(90, 0, 0);
        agent = GetComponent<NavMeshAgent>();
        child = transform.GetChild(0);
        player = GameObject.FindWithTag("Player").transform;

        agent.destination = player.position;

    }

    // Update is called once per frame
    void Update()
    {
        direction.y = -transform.rotation.y;
        child.rotation = Quaternion.Euler(direction);
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            StartCoroutine(Waiter());
            timer = 0;
        }


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Waiter()); //Calls coroutine to stop movement
        }


    }


    IEnumerator Waiter() //Sleep for 2 seconds to allow players to escape
    {
        agent.speed = 0;
        yield return new WaitForSecondsRealtime(2);
        agent.speed = 15;
        if (player) //If player hasn't died, go to wherever it was two seconds ago
        {
            agent.destination = player.position;
        }

    }

}
