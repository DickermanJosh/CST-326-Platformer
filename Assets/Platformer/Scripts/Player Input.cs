using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask ground;
    private float xAxis;
    public float moveSpeed;
    public float jumpStrength;
    public float rayDistance = 1.0f;
    public AudioSource jumpSound;
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        // allow the player to jump if they are touching the ground
        if (Input.GetButtonDown("Jump") && touchingGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpStrength, 0f);
            jumpSound.Play();
        }
        // variable jump height based on how long the space bar is held
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, 0f);
        }
    }
    private void FixedUpdate()
    {
        // normal velocity given if player is touching the ground or not touching the walls
        if(touchingGround() || !touchingWalls()) rb.velocity = new Vector3(xAxis * moveSpeed*Time.deltaTime, rb.velocity.y, 0f);
      
        if (!touchingGround() && touchingWalls() )
        {
            // if the player is touching the walls and not the ground apply a negative y velocity to avoid sticking to walls
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 2f, 0f);
        }
    }
    public bool touchingGround()
    {
        // cast a ray from the players feet and return true if it touches a block
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance, ground))
        {
            return true;
        }

        return false;
    }
    private bool touchingWalls()
    {
        // Cast a ray to the left and right of the player and return true of either of the rays comes into contact with a block
        Ray rayLeft = new Ray(transform.position, Vector3.left);
        Ray rayRight = new Ray(transform.position, Vector3.right);
        Debug.DrawRay(transform.position,Vector3.right,Color.blue);
        Debug.DrawRay(transform.position,Vector3.left,Color.red);

        RaycastHit hit;
        if (Physics.Raycast(rayLeft, out hit, 0.5f, ground)) return true;
        if (Physics.Raycast(rayRight, out hit, 0.5f, ground)) return true;
        return false;
    }
}