using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] target;
    [SerializeField] private float eSpeed = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] bool stunned = false;
    [SerializeField] float stunTimerInit = 5.0f;
    [SerializeField] float stunTimer;
    [SerializeField] private CapsuleCollider light;
    [SerializeField] private AudioSource playing;

    private int eSpeedFloatHash;
    private int current;

    void Start()
    {
        animator = GetComponent<Animator>();
        eSpeedFloatHash = Animator.StringToHash("eSpeed");
        if (stunned) {
            eSpeed = 0f;
        }
        light.gameObject.SetActive(!stunned);
        playing.Play();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet"){
            stunned = true;
            stunTimer = stunTimerInit;
        }
    }
}
