using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLongEnough : MonoBehaviour
{
    public GameObject WinPanel;
    private void OnTriggerEnter(Collider other)
    {
       
        
        
        if(other.gameObject.CompareTag("Player"))
        {
            CindyMovement.win = true;
            other.GetComponent<Animator>().SetBool("Win", true);
            WinPanel.SetActive(true);

        }
      
    }

   
}
