using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Animator animator;
    
    private int speedFloatHash;
    private int crouchBoolHash;
    private bool crouched = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        speedFloatHash = Animator.StringToHash("speed");
        crouchBoolHash = Animator.StringToHash("crouch");
    }

    void Update()
    {
        Move();
    }

    //Moves the player in cardinal directions, working on improvements
    void Move()
    {
        if (Input.GetKey(KeyCode.W))    //straight ahead
        {
            animator.SetFloat(speedFloatHash, speed);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -90, 0));
        }
        if (Input.GetKey(KeyCode.A))    //left
        {
            animator.SetFloat(speedFloatHash, speed);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.S))    //backwards
        {
            animator.SetFloat(speedFloatHash, speed);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
        }
        if (Input.GetKey(KeyCode.D))    //right
        {
            animator.SetFloat(speedFloatHash, speed);
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
        }

        //if not moving, stop the character
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            animator.SetFloat(speedFloatHash, 0f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
    }

    //Toggles crouching animation
    void Crouch()
    {
        animator.SetBool(crouchBoolHash, !crouched);
        crouched = !crouched;
    }

    private void OnCollisionEnter(Collision collision)
    {
        animator.SetFloat(speedFloatHash, 0f);
    }

}
