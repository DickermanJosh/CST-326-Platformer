using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int startTime = 400;
    // Update is called once per frame
    void Update()
    {
        // Count down from 400 in full seconds
        int wholeSecond = (int)Math.Floor(Time.realtimeSinceStartup) ;
        wholeSecond  = startTime - wholeSecond;
        timerText.text = $"Time\n{wholeSecond.ToString()}";
    }
}
