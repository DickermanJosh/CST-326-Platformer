using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (other.CompareTag("Mario"))
        {
            if (currentScene == 0)
                SceneManager.LoadScene(1); // Loads scene with custom level
            else
                SceneManager.LoadScene(0); // Reloads 1-1 at the end of the custom level
        }
    }
}