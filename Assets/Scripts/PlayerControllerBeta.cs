using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBeta : MonoBehaviour
{

    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float rotRate = 1440;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;

    private float animSpeed; 
    private int speedFloatHash;
    private int crouchBoolHash;
    private bool crouched = false;

    void Start()
    {
        animSpeed = speed * 20;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        speedFloatHash = Animator.StringToHash("speed");
        crouchBoolHash = Animator.StringToHash("crouch");
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Move(dir);
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
    }

    private void Move(Vector3 movement)
    {
        rb.AddForce(movement * speed);
        //animator.SetFloat(speedFloatHash, animSpeed);

        if (movement.x == 0f && movement.z == 0)
        {
            animator.SetFloat(speedFloatHash, 0f);
        }
    }

    private void Turn(float ang)
    {
        transform.Rotate(0, ang * rotRate * Time.deltaTime, 0);
    }

    void Crouch()
    {
        animator.SetBool(crouchBoolHash, !crouched);
        crouched = !crouched;
    }
}
