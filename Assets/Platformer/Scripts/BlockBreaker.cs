using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreaker : MonoBehaviour
{
    public LayerMask breakable;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // get the pos of the mouse in world space and cast a ray to it from the pos of the camera
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);
        // if the user clicks on an object with the layer breakable assigned to it the block will be destroyed
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(mouseRay, out hit, 50, breakable))
            {
                //Debug.Log(hit.transform.name);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}