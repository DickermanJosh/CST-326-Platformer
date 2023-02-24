using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public LayerMask breakable;
    public AudioSource blockbreak;
    private Vector3 rayDir;
    private Vector3 rayOrigin;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        // cast a ray from the top of the player
        rayOrigin = transform.position + Vector3.up * (transform.localScale.y / 2);
        rayDir = Vector3.up;
        Debug.DrawRay(rayOrigin, rayDir, Color.red);
        // if that ray comes into contact with an object that is in the breakable layer, it is destroyed
        if (Physics.Raycast(rayOrigin, rayDir, out hit, 0.1f, breakable))
        {
            Debug.Log(hit.transform.name);
            blockbreak.Play();
            Destroy(hit.transform.gameObject);
        }
    }
}

