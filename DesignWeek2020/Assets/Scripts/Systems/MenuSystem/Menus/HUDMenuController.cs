using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDMenuController : Menu
{

    public GameObject catfact1;
    public GameObject catfact2;
    public GameObject catfact3;

    private void Update()
    {
        //int minutes = (int)GameManager.Instance.secondsLeft / 60;
        //int seconds = (int)GameManager.Instance.secondsLeft % 60;
        //TimeSpan ts = new TimeSpan(0, minutes, seconds);
        //gameClockText.text = ts.ToString(@"m\:ss");
    }

    public void RevealCatFact()
    {
        if (!catfact1.activeSelf)
        {
            catfact1.SetActive(true);
        }
        else if (!catfact2.activeSelf)
        {
            catfact2.SetActive(true);
        }
        else if (!catfact3.activeSelf)
        {
            catfact3.SetActive(true);
        }
    }
}
