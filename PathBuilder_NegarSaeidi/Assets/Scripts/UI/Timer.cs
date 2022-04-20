using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public GameObject timerText;
    public static float time;
    public static bool startTime;
    public GameObject closeDoor, openDoor;
    private void Start()
    {
        time = 10;
    }
    void Update()
    {
        if (startTime)
        {
            if (time > 1)
            {
                time -= Time.deltaTime;
            }
            else
            {
                SetDestination();
            }
            timerText.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt(time % 60).ToString();
        }
    }
    private void SetDestination()
    {
        Destroy(closeDoor.gameObject);
        TileStack.TimeIsUp = true;
        openDoor.gameObject.SetActive(true);
    }
}