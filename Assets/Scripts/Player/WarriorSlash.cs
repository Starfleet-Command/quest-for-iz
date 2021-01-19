/*
    Script to move the Warrior and let them attack
    Made by: Juan Francisco Gortarez
    On: 29/02/2020

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSlash : MonoBehaviour
{
    public ParticleSystem buff;

    float moveSpeed;
    Vector3 movement;
    public Rigidbody rb;
    public Animator animator;
    public AudioClip walk;

    AudioSource playerSounds;

    GameObject swordCopy;
    //Charged Attack
    public float ChargedShotTimer = 0;
    int angle;

    bool cooldownActive = false;

    //Variables for Sword Arcs
    public GameObject sword;


    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = this.gameObject.GetComponent<AudioSource>();
        moveSpeed = PlayerPrefs.GetInt("MoveSpd") * 3;
        rb = GetComponent<Rigidbody>(); //rb is now the rigid body of this object.
        buff.Stop();
        cooldownActive = false;

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //Get the directions from the user
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            playerSounds.clip = walk;
            playerSounds.Play();
        }

        // Apply direct translation to the object transform.Translate(motion);
        //
        //rb.velocity = motion * speed * Time.deltaTime;


        //Direction of shooting
        if (movement.x > 0)
        {
            angle = 90;

        }
        else if (movement.x < 0)
        {
            angle = 270;

        }
        else if (movement.z > 0)
        {
            angle = 0;

        }
        else if (movement.z < 0)
        {
            angle = 180;
        }

        //Section of the code that handles player attacks

        //Shooting
        if (Input.GetButtonDown("Fire1") && !cooldownActive)
        {
            swordCopy = Instantiate(sword, rb.position, Quaternion.Euler(90, angle, 0));
            swordCopy.transform.parent = transform;
            StartCoroutine(Cooldown());
        }

        //Charged Shot
        //Cargar el ataque
        if (Input.GetButton("Fire2") && (movement.x == 0) && (movement.z == 0) && !cooldownActive)
        {
            ChargedShotTimer += Time.deltaTime;
        }

        if (ChargedShotTimer > 2)
        {
            buff.Play();
        }

        if ((Input.GetButtonUp("Fire2")) && (ChargedShotTimer > 2) && !cooldownActive)
        {
            GameObject swordCopy2;  //Heavy attack is a double sweep

            swordCopy = Instantiate(sword, rb.position, Quaternion.Euler(90, angle, 0));
            swordCopy2 = Instantiate(sword, rb.position, Quaternion.Euler(90, -angle, 0));
            swordCopy.transform.parent = transform;
            swordCopy2.transform.parent = transform;
            ChargedShotTimer = 0;
            buff.Stop();
            StartCoroutine(Cooldown());
        }

        if ((Input.GetButtonUp("Fire2")) && (ChargedShotTimer < 2))
        {
            ChargedShotTimer = 0;

        }

        if (Input.GetButton("Fire2") && movement.x > 0 && movement.z > 0)
        {
            ChargedShotTimer = 0;
            buff.Stop();
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }


    IEnumerator Cooldown() //Does not allow the player to attack for a length of time depending on their attack speed
    {
        cooldownActive = true;
        yield return new WaitForSecondsRealtime((float)(1 - (PlayerPrefs.GetInt("AtkSpd") * 0.2)));

        cooldownActive = false;
    }
}
