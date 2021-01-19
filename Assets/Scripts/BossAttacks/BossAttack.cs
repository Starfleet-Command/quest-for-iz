using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float timer;
    public HealthBar BossHealth;
    //GameObject BossHealthClass;

    //LaserBeam variables:
    public GameObject Laser;
    public GameObject LaserFire;
    //public Material LaserCharge;
    //public Material LaserFire;
    private Renderer LaserRend1;
    private Renderer LaserRend2;
    public Vector3 LaserPos1;
    public Vector3 LaserPos2;
    //Sounds
    public AudioClip AFire;
    private AudioSource LaserSound;

    //BulletHell variables:
    public GameObject Bullet;
    public Rigidbody BossRB;
    private int angle = 90;

    //Hands variables
    public GameObject LeftHand;
    public GameObject RightHand;

    public Vector3 LeftPos1, LeftPos2, RightPos1, RightPos2;
    public bool MoveHands = false;

    //Bomb Attack
    public GameObject[] Bombs;
    public GameObject[,] BombPattern = new GameObject[6, 6];

    int randomPattern;

    public GameObject Explosion;

    //Ricardo
    public bool RicardoBool = false;
    public GameObject Ricardo;
    public GameObject[] RicardoPos;

    //BulletHell
    public GameObject SnoopDog;

    void FillPattern()
    {
        //Pattern 1: 123 456
        BombPattern[0, 0] = Bombs[0];
        BombPattern[0, 1] = Bombs[1];
        BombPattern[0, 2] = Bombs[2];
        BombPattern[0, 3] = Bombs[3];
        BombPattern[0, 4] = Bombs[4];
        BombPattern[0, 5] = Bombs[5];

        //Pattern 2: 135 246
        BombPattern[1, 0] = Bombs[0];
        BombPattern[1, 1] = Bombs[2];
        BombPattern[1, 2] = Bombs[4];
        BombPattern[1, 3] = Bombs[1];
        BombPattern[1, 4] = Bombs[3];
        BombPattern[1, 5] = Bombs[5];

        //Pattern 3: 145 236
        BombPattern[2, 0] = Bombs[0];
        BombPattern[2, 1] = Bombs[3];
        BombPattern[2, 2] = Bombs[4];
        BombPattern[2, 3] = Bombs[1];
        BombPattern[2, 4] = Bombs[2];
        BombPattern[2, 5] = Bombs[5];

        //Pattern 4: 236 145
        BombPattern[3, 0] = Bombs[1];
        BombPattern[3, 1] = Bombs[2];
        BombPattern[3, 2] = Bombs[5];
        BombPattern[3, 3] = Bombs[0];
        BombPattern[3, 4] = Bombs[3];
        BombPattern[3, 5] = Bombs[4];

        //Pattern 5: 246 135
        BombPattern[4, 0] = Bombs[1];
        BombPattern[4, 1] = Bombs[3];
        BombPattern[4, 2] = Bombs[5];
        BombPattern[4, 3] = Bombs[0];
        BombPattern[4, 4] = Bombs[2];
        BombPattern[4, 5] = Bombs[4];

        //Pattern 6: 456 123
        BombPattern[5, 0] = Bombs[3];
        BombPattern[5, 1] = Bombs[4];
        BombPattern[5, 2] = Bombs[5];
        BombPattern[5, 3] = Bombs[0];
        BombPattern[5, 4] = Bombs[1];
        BombPattern[5, 5] = Bombs[2];
    }


    // Start is called before the first frame update
    void Start()
    {
        LaserSound = GetComponent<AudioSource>();
        LaserSound.clip = AFire;
        FillPattern();
    }



    // Update is called once per frame
    void Update()
    {
        //BossHealth = gameObject.GetComponent<HealthBar>();
        //General Timer
        timer += Time.deltaTime;

        //LaserBeam Start
        if (timer >= 7)
        {

            //Phase 1 
            if (BossHealth.size >= 0.66f)
            {
                //Fire Bullet Hell
                StartCoroutine(BulletFire2());

                //Create clone of LaserBeam

                //Sound
                StartCoroutine(LaserBeam());
                timer = -2;
            }

            //Phase 2
            else if (BossHealth.size >= 0.33f)
            {
                //Random pattern
                randomPattern = Random.Range(0, 6);

                StartCoroutine(BombsPhase1(randomPattern));

                timer = -5f;
            }

            else if (BossHealth.size < 0.33f)
            {

                //Spawn Ricardo
                if (RicardoBool == false)
                {
                    StartCoroutine(RicardoMethod());
                    RicardoBool = true;
                }

                //Spawn SnoopDog
                SnoopDog.SetActive(true);
                StartCoroutine(LaserBeam());

                timer = -3;
            }



        }


        //Move Hands
        if ((LeftHand.transform.position.z >= LeftPos2.y) && (MoveHands == true))
        {
            LeftHand.transform.Translate(Vector3.up * 8.5f * Time.deltaTime);
            RightHand.transform.Translate(Vector3.up * 8.5f * Time.deltaTime); //= Vector3.MoveTowards(LeftHand.transform.position, LeftPos2, 1.5f*Time.deltaTime);//MoveTowards(LeftPos1,LeftPos2,0.20f);
        }
        else if ((LeftHand.transform.position.z <= 5) && (MoveHands == false))
        {
            LeftHand.transform.Translate(Vector3.down * 8.5f * Time.deltaTime);
            RightHand.transform.Translate(Vector3.down * 8.5f * Time.deltaTime);

        }


        //Spawn Ricardo
        IEnumerator RicardoMethod()
        {

            GameObject RicardoClone = (GameObject)Instantiate(Ricardo, RicardoPos[0].transform.position, Quaternion.Euler(90, 0, 0));
            float travelduration = 2f;
            //While the game is running...
            while (Application.isPlaying)
            {
                //Travel from 1 to 2
                float counter = 0f;
                while (counter < travelduration)
                {
                    RicardoClone.transform.position = Vector3.Lerp(RicardoPos[0].transform.position, RicardoPos[1].transform.position, counter / travelduration);
                    counter += Time.deltaTime;
                    yield return null;
                }

                //Make sure we are exactly at point 2
                RicardoClone.transform.position = RicardoPos[1].transform.position;

                //Now we repeat for 2,3,4

                //Travel from 2 to 3
                counter = 0f;
                while (counter < travelduration)
                {
                    RicardoClone.transform.position = Vector3.Lerp(RicardoPos[1].transform.position, RicardoPos[2].transform.position, counter / travelduration);
                    counter += Time.deltaTime;
                    yield return null;
                }
                RicardoClone.transform.position = RicardoPos[2].transform.position;

                //Travel from 3 to 4
                counter = 0f;
                while (counter < travelduration)
                {
                    RicardoClone.transform.position = Vector3.Lerp(RicardoPos[2].transform.position, RicardoPos[3].transform.position, counter / travelduration);
                    counter += Time.deltaTime;
                    yield return null;
                }
                RicardoClone.transform.position = RicardoPos[3].transform.position;


                //Travel from 4 to 1
                counter = 0f;
                while (counter < travelduration)
                {
                    RicardoClone.transform.position = Vector3.Lerp(RicardoPos[3].transform.position, RicardoPos[0].transform.position, counter / travelduration);
                    counter += Time.deltaTime;
                    yield return null;
                }
                RicardoClone.transform.position = RicardoPos[0].transform.position;
            }
        }

    }

    IEnumerator LaserBeam()
    {
        GameObject laserClone1 = (GameObject)Instantiate(Laser, LaserPos1, Quaternion.Euler(90, -45, 0));
        GameObject laserClone2 = (GameObject)Instantiate(Laser, LaserPos2, Quaternion.Euler(90, 45, 0));
        yield return new WaitForSeconds(2.4f);
        Destroy(laserClone1);
        Destroy(laserClone2);
        GameObject LaserFireClone1 = (GameObject)Instantiate(LaserFire, LaserPos1, Quaternion.Euler(90, -45, 0));
        GameObject LaserFireClone2 = (GameObject)Instantiate(LaserFire, LaserPos2, Quaternion.Euler(90, 45, 0));

        LaserSound.Play();
        Debug.Log("Lasers Fired");
        laserClone1.tag = "LaserDamage";
        laserClone2.tag = "LaserDamage";


        yield return new WaitForSeconds(0.5f);
        Destroy(LaserFireClone1);
        Destroy(LaserFireClone2);

    }

    IEnumerator BulletFire2()
    {
        angle = 0;
        for (int i = 1; i <= 12; i++)
        {
            GameObject BulletClone = (GameObject)Instantiate(Bullet, BossRB.position, Quaternion.Euler(0, 90 + (i * 15), 0));
            BulletClone.tag = "BulletHell";
            angle = angle - 18;
        }
        yield return new WaitForSeconds(3.0f);
        angle = -20;
        for (int i = 1; i <= 12; i++)
        {
            GameObject BulletClone = (GameObject)Instantiate(Bullet, BossRB.position, Quaternion.Euler(0, 90 + (i * 15) + 7, 0));
            BulletClone.tag = "BulletHell";
            angle = angle - 30;
        }
        StartCoroutine(DestroyBullets());
        MoveHands = true; //After the final bullets fire, move hands down.
    }

    IEnumerator BulletFire1()
    {
        angle = 0;
        for (int i = 1; i <= 12; i++)
        {
            GameObject BulletClone = (GameObject)Instantiate(Bullet, BossRB.position, Quaternion.Euler(0, 90 + (i * 15), 0));
            BulletClone.tag = "BulletHell";
            angle = angle - 18;
        }
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(DestroyBullets());
    }

    IEnumerator DestroyBullets()
    {
        yield return new WaitForSeconds(2.5f);
        MoveHands = false;
        GameObject[] Bullets;
        Bullets = GameObject.FindGameObjectsWithTag("BulletHell");

        for (var i = 0; i < Bullets.Length; i++)
        {
            Destroy(Bullets[i]);
        }
    }

    //Spawn Bombs1 and then spawn Bombs2
    IEnumerator BombsPhase1(int randomPattern)
    {
        //Bombs1
        for (int i = 0; i < 3; i++)
        {
            GameObject BombClone1 = (GameObject)Instantiate(BombPattern[randomPattern, i], BombPattern[randomPattern, i].transform.position, Quaternion.Euler(0, 0, 0));
            BombClone1.tag = "Bombs1";
        }
        //GameObject[] DestroyBombs1 = GameObject.FindGameObjectsWithTag("Bombs1");
        yield return new WaitForSeconds(2f);

        //Bombs2
        for (int i = 3; i < 6; i++)
        {
            GameObject BombClone2 = (GameObject)Instantiate(BombPattern[randomPattern, i], BombPattern[randomPattern, i].transform.position, Quaternion.Euler(0, 0, 0));
            BombClone2.tag = "Bombs2";
        }
        StartCoroutine(BombsPhase2());

    }

    IEnumerator BombsPhase2()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject[] DestroyBombs1 = GameObject.FindGameObjectsWithTag("Bombs1");
        for (var i = 0; i < DestroyBombs1.Length; i++)
        {
            GameObject ExplosionClone = (GameObject)Instantiate(Explosion, DestroyBombs1[i].transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(DestroyBombs1[i]);
        }
        StartCoroutine(BombsPhase3());
        StartCoroutine(BulletFire1());
    }

    IEnumerator BombsPhase3()
    {
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(BulletFire1());
        GameObject[] DestroyBombs2 = GameObject.FindGameObjectsWithTag("Bombs2");
        for (var i = 0; i < DestroyBombs2.Length; i++)
        {
            GameObject ExplosionClone = (GameObject)Instantiate(Explosion, DestroyBombs2[i].transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(DestroyBombs2[i]);
        }
    }

}
