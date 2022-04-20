using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnTutorial()
    {
        SceneManager.LoadScene("Tutorial");

    }
    public void OnMenu()
    {
        SceneManager.LoadScene("Menu");


    }
    public void OnCredit()
    {
        SceneManager.LoadScene("Credit");


    }
}
