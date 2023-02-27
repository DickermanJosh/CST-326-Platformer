using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject mario;

    public Rigidbody rb;
    public Animator animate;
    private float speed;

    private void Start()
    {
    }

    void Update()
    {
        speed = rb.velocity.magnitude;
        animate.SetFloat("Speed", speed);
        animate.SetBool("Jumping", !mario.GetComponent<PlayerInput>().TouchingGround());
    }
}