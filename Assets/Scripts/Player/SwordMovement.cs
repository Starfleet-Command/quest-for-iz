using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{

    public float speed = 8f;


    Vector3 startPos;
    float counter;

    Quaternion initAngle;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (counter < 180)
        {


            // Move the transform
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(90, 0, 0), Quaternion.Euler(90, 0, 180), counter / 180);

            // Update Counter
            counter += speed;


        }

        else Destroy(gameObject);

    }
}
