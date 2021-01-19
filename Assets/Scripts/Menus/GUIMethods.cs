using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMethods : MonoBehaviour 
{

    public void GotoScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SelectCharacter(string classType)
    {
        PlayerPrefs.SetString("PlayerClass", classType);
        Debug.Log("Selecting class");
        //GotoScene("Game");
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(0);
    }

}