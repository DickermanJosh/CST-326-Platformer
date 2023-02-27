using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Break : MonoBehaviour
{
    public TextMeshProUGUI MarioPoints;
    public TextMeshProUGUI CoinCount;
    public LayerMask breakable;
    public LayerMask coin;
    public AudioSource blockbreak;
    public AudioSource coinsound;
    private Vector3 rayDir;
    private Vector3 rayOrigin;
    private int points;
    private float coins;
    RaycastHit hit;
    // Update is called once per frame
    void FixedUpdate()
    {
        // cast a ray from the top of the player
        rayOrigin = transform.position + Vector3.up * Mathf.Max(transform.localScale.y);
        rayDir = Vector3.up;
        Debug.DrawRay(rayOrigin, rayDir, Color.green);
        // if that ray comes into contact with an object that is in the breakable layer, it is destroyed
        if (Physics.Raycast(rayOrigin, rayDir, out hit, 0.35f, breakable))
        {
            Debug.Log(hit.transform.name);
            blockbreak.Play();
            Destroy(hit.transform.gameObject);
            points += 100;
            MarioPoints.text = $"MARIO\n{points.ToString()}";
        }
        else if(Physics.Raycast(rayOrigin, rayDir, out hit, 0.35f, coin))
        {
            Debug.Log(hit.transform.name);
            coinsound.Play();
            points += 20;
            MarioPoints.text = $"MARIO\n{points.ToString()}";
            coins += 0.2f;
            
            CoinCount.text = $"x{Math.Round(coins).ToString()}";
        }
    }
}

