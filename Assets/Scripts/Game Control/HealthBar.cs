using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bar;
    private float health = 5000;
    public float size;
    public void SetSize(float size)
    {
        bar.localScale = new Vector4(size, 1, 1);
    }
    private void Start()
    {
        SetSize(1f);
    }

    public void TakeDamage(int dmg)
    {

        health = health - dmg;
        if (health >= 0)
        {
            size = health / 5000;
        }
        else size = 0;

        SetSize(size);

        if (health <= 0)
        {
            this.gameObject.GetComponent<VictoryScreen>().OnWin();
        }

    }


}
