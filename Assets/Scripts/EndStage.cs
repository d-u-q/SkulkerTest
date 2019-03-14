using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //CHANGE THIS TO BE NEXT SCENE
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
