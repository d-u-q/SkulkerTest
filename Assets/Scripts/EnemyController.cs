using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] target;
    [SerializeField] private float eSpeed = 3f;
    [SerializeField] private Animator animator;

    private int eSpeedFloatHash;
    private int current;

    void Start()
    {
        animator = GetComponent<Animator>();
        eSpeedFloatHash = Animator.StringToHash("eSpeed");
    }

    void Update()
    {
        if (transform.position != target[current].position)
        {
            animator.SetFloat(eSpeedFloatHash, eSpeed);
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, eSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            transform.LookAt(target[current].position);
        }
        else
        {
            //TODO: add a wait timer here
            current = (current + 1) % target.Length;
        }
    }
}
