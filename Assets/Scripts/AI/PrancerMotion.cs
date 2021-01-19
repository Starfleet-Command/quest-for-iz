using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    Script that sets the motion and interaction of the shambling enemy
    Juan Francisco Gortarez
    23/01/2020

*/

public class PrancerMotion : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Transform child;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        child = transform.GetChild(0);
        direction = new Vector3(90, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {
        direction.y = -transform.rotation.y;
        child.rotation = Quaternion.Euler(direction);
        if (player) //If player hasn't died, go to wherever it is now
        {
            agent.destination = player.position;
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
        agent.speed = 2.5f;
    }

}
