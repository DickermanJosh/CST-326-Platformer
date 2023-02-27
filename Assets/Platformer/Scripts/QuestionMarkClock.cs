using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkClock : MonoBehaviour
{
    public Material Question;
    private float startTime;
    private float wholeSeconds;
    private float yTiling;

    private float elapsedSeconds;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        // increment the offset of the ? texture by 0.2 every whole second
        elapsedSeconds = Time.realtimeSinceStartup - startTime;
        wholeSeconds = Mathf.Floor(elapsedSeconds);
        yTiling = wholeSeconds * 0.2f;
        Question.mainTextureOffset = new Vector2(0, yTiling);
    }
}