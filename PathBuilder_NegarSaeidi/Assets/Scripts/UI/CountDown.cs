using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountDown : MonoBehaviour
{
    public GameObject Readytxt;
    public GameObject GoTxt;
    private void Start()
    {
        StartCoroutine(causeDelayForReady(1.0f));
    }
    IEnumerator causeDelayForReady(float time)
    {
        yield return new WaitForSeconds(time);
        Readytxt.gameObject.SetActive(false);
        GoTxt.SetActive(true);
        StartCoroutine(causeDelayForGo(1.0f));
    }
    IEnumerator causeDelayForGo(float time)
    {
        yield return new WaitForSeconds(time);
        GoTxt.gameObject.SetActive(false);
        Timer.startTime = true;
        CindyMovement.startMovement = true;
    }
}
