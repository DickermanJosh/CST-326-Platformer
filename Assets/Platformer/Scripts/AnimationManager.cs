using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public Rigidbody rb;
    public Animator animation;
    private float speed;
    void Update()
    {
        speed = rb.velocity.magnitude;
        animation.SetFloat("Speed",speed);
        animation.SetBool("Jumping",!playerInput.touchingGround());
    }
}
