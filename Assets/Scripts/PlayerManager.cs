using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private int speedFloatHash;
    private int crouchBoolHash;
    private bool crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speedFloatHash = Animator.StringToHash("speed");
        crouchBoolHash = Animator.StringToHash("crouch");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat(speedFloatHash, 1f);
        }
        else
        {
            animator.SetFloat(speedFloatHash, 0f);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
        }
    }

    void Crouch()
    {
        animator.SetBool(crouchBoolHash, !crouched);
        crouched = !crouched;
    }
}
