using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDMenuController : Menu
{
    public Text gameClockText;

    private void Update()
    {
        int minutes = (int)GameManager.Instance.secondsLeft / 60;
        int seconds = (int)GameManager.Instance.secondsLeft % 60;
        TimeSpan ts = new TimeSpan(0, minutes, seconds);
        gameClockText.text = ts.ToString(@"m\:ss");
    }
}
