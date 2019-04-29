using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().name == "Warehouse")
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Hangar", LoadSceneMode.Single);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Hangar")
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            }
        }
    }
}
