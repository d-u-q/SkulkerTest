using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private AudioSource alert;

    public float passedTime;

    private void Update()
    {
        if (passedTime > 0) {
            passedTime -= Time.deltaTime;
        }
        if (passedTime < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            alert.Play();
            passedTime = 2.0f;            
        }
    }
}
