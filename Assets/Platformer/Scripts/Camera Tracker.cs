using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.x > 15.5)
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y,
                this.transform.position.z);
    }
}