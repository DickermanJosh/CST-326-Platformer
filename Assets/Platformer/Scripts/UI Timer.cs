using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private int startTime;
    private int wholeSecond;
    private void Start()
    {
        startTime = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count down from 100 in full seconds
        wholeSecond = (int)Math.Floor(Time.timeSinceLevelLoad);
        
        wholeSecond = startTime - wholeSecond;
        timerText.text = $"Time\n{wholeSecond.ToString()}";
        if(timerText.text.Equals("Time\n0")) Debug.Log("Times up!");
    }
}