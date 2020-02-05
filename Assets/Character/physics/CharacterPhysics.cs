using UnityEngine;
using System.Collections;
using System;

public class CharacterPhysics : MonoBehaviour
{
    public float gravity = 1;
    private CharacterController controller;
    private bool grounded;
    private float velocityY = 0;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
    }

    public bool IsGrounded { get { return grounded;  } }

    public void Move(Vector3 movement, Quaternion steering)
    {
        grounded = controller.isGrounded;
        transform.rotation = steering;

        if (grounded)
        {
            velocity = movement;
            velocityY = -2 * gravity * Time.deltaTime;//-controller.stepOffset / Time.deltaTime; 
        }
        else
        {
            //velocity = velocity * 1.09f;
            velocityY -= gravity * Time.deltaTime;
        }

        controller.Move(velocity + Vector3.up * velocityY);
    }
    
}
