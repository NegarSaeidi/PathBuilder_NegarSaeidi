using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLongEnough : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        
        
        if(other.gameObject.CompareTag("Player"))
        {
         
            other.GetComponent<Animator>().SetBool("Win", true);
        }
      
    }
}
