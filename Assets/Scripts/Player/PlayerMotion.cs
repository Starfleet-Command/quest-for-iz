/*
    Script to move the player object
    Tlacuachi Poi 
    A01025211

    Updated by: Daniel Roa
            On: January 30, 2020

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    //When a variable is public float, you cna edit it inside Unity.
    public ParticleSystem buff;

    float moveSpeed;
    Vector3 movement;
    public Rigidbody rb;
    public Animator animator;
    public GameObject fProjectile;

    GameObject swordCopy;
    //public AudioClip walk;

    AudioSource playerSounds;

    //Charged Shot
    public GameObject sProjectile;
    public float ChargedShotTimer = 0;
    int angle;

    bool cooldownActive = false;
    Transform Gun;

    // Start is called before the first frame update
    void Start()
    {
        playerSounds = this.gameObject.GetComponent<AudioSource>();
        moveSpeed = PlayerPrefs.GetInt("MoveSpd") * 3;
        rb = GetComponent<Rigidbody>(); //rb is now the rigid body of this object.
        buff.Stop();

    }

    // Update is called once per frame
    void Update()
    {

        //Get the directions from the user
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        /*if (movement.x != 0 || movement.y != 0)
        {
            playerSounds.clip = walk;
            playerSounds.Play();
        
        }*/

        // Apply direct translation to the object transform.Translate(motion);
        //
        //rb.velocity = motion * speed * Time.deltaTime;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        animator.SetFloat("Speed", movement.sqrMagnitude);

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
            Instantiate(fProjectile, rb.position, Quaternion.Euler(0, angle, 0));
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
            //buff.SetActive(true);
        }

        if ((Input.GetButtonUp("Fire2")) && (ChargedShotTimer > 1.5) && (!cooldownActive))
        {
            Instantiate(sProjectile, rb.position, Quaternion.Euler(0, angle, 0));
            ChargedShotTimer = 0;
            buff.Stop();
            StartCoroutine(Cooldown());
        }

        if ((Input.GetButtonUp("Fire2")) && (ChargedShotTimer < 1.5))
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
