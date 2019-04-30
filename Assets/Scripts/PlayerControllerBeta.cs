using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBeta : MonoBehaviour
{

    public float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;    

    public float animSpeed;
    private int speedFloatHash;
    private int crouchBoolHash;
    private bool crouched = false;
    public bool moving = true;
    public float distToGround;
    public bool grounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        speedFloatHash = Animator.StringToHash("speed");
        crouchBoolHash = Animator.StringToHash("crouch");
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");        

        Vector3 dir = new Vector3(moveHorizontal, rb.velocity.y, moveVertical);
        dir = dir.normalized;
        animSpeed = rb.velocity.magnitude;        
        Move(dir);        
    }

    void Move(Vector3 movement)
    {
        isGrounded();
        if (movement.x !=0 || movement.z !=0) {
            moving = true;
        }
        else {
            moving = false;
        }

        if (!moving) {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (rb.velocity.magnitude > .1)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0.0f, rb.velocity.z));

            if (rb.velocity.magnitude > 2) {
                rb.velocity = rb.velocity.normalized * 0.001f;
            }
        }

        if (grounded) {
            speed = 10 * (crouched ? 0.1f : 1) + 40;
        }
        else {
            speed = 40 * (crouched ? 0.1f : 1) + 160;
        }
        rb.AddForce(movement.x * speed, System.Math.Abs(movement.y) * -1 * speed, movement.z * speed);
        animator.SetFloat(speedFloatHash, animSpeed);
    }

    private void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Stairs"){
            speed = 200;
        }

    }

    void Crouch()
    {
        animator.SetBool(crouchBoolHash, !crouched);
        crouched = !crouched;
    }

    bool isGrounded()
    {
        grounded = Physics.Raycast(transform.position, -Vector3.up, 0.1f);
        return grounded;
    }
}
