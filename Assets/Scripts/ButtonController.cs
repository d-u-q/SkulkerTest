using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject toolTip;
    public float dis;
    public float speed;
    private bool open = false;

    void Update()
    {
        toolTip.SetActive(false);
        dis = (Vector3.Distance(player.transform.position, gameObject.transform.position));
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2f) {
            toolTip.SetActive(true);
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.T)) {
            open = !open;
        }
        door.transform.rotation = Quaternion.Slerp(door.transform.rotation, Quaternion.Euler( 0,(open ? 180: 90), 0), speed * Time.deltaTime);        
    }

    void Interact()
    {
        if (Input.GetButtonDown("Interact")) {            
            open = !open;
        }
    }

}
