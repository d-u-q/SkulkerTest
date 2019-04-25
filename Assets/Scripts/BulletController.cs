using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Awake()
    {
        Object.Destroy(gameObject, 1.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Object.Destroy(gameObject);
    }
}
