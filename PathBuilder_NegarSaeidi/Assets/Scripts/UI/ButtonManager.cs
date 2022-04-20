using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public GameObject pausePanel;
  
    public void OnReusme()
    {
        pausePanel.SetActive(false);
        
        CindyMovement.IsPaused = false;

    }
    public void OnMenu()
    {
        SceneManager.LoadScene("Menu");
      
    
    }
}
