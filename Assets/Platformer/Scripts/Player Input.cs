using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask ground;
    private float xAxis;
    private bool isFacingRight = true;
    public float moveSpeed;
    public float jumpStrength;
    public float rayDistance = 0.25f;
    public float sprintBoost = 2;

    public AudioSource jumpSound;
    //public Transform rotate;

    void Update()
    {
        TouchingGround();
        TouchingWalls();
        SwitchDirection();
        xAxis = Input.GetAxisRaw("Horizontal");
        // allow the player to jump if they are touching the ground
        if (Input.GetButtonDown("Jump") && TouchingGround())
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
        if (TouchingGround() || !TouchingWalls())
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity =
                    new Vector3(xAxis * (moveSpeed * sprintBoost) * Time.deltaTime, rb.velocity.y,
                        0f); // Sprinting with shift
            }
            else
            {
                rb.velocity = new Vector3(xAxis * moveSpeed * Time.deltaTime, rb.velocity.y, 0f); // walking normally
            }
        }

        if (!TouchingGround() && TouchingWalls())
        {
            // if the player is touching the walls and not the ground apply a negative y velocity to avoid sticking to walls
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 2f, 0f);
        }
    }

    public bool TouchingGround()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        // cast a ray from the players feet and return true if it touches a block
        Ray ray = new Ray(pos, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(pos, Vector3.down, Color.magenta);
        if (Physics.Raycast(ray, out hit, rayDistance, ground)) return true;
        return false;
    }

    public bool TouchingWalls()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        // Cast a ray to the left and right of the player and return true of either of the rays comes into contact with a block
        Ray rayLeft = new Ray(pos, Vector3.left);
        Ray rayRight = new Ray(pos, Vector3.right);
        Debug.DrawRay(pos, Vector3.right, Color.blue);
        Debug.DrawRay(pos, Vector3.left, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(rayLeft, out hit, 0.5f, ground)) return true;
        if (Physics.Raycast(rayRight, out hit, 0.5f, ground)) return true;
        return false;
    }

    private void SwitchDirection()
    {
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(new Vector3(0f, 180f, 0f));
        }
    }
}