using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForLose : MonoBehaviour
{
    public GameObject LosePanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (LosePanel == null)
            {
                GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);
                foreach (GameObject go in allObjects)
                {
                    if (go.CompareTag("LosePanel"))
                        LosePanel = go;
                }
            }
            CindyMovement.lose = true;
            LosePanel.gameObject.SetActive(true);
            other.GetComponent<Animator>().SetBool("Lose", true);
        }
        else if(other.gameObject.CompareTag("WinDoor"))
        {
            Destroy(gameObject);
        }
    }
}
