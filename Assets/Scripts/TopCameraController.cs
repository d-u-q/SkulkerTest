using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public Vector3 above;
    public Vector3 behind;
    public Vector3 playerWaist;
    
    void Awake()
    {
        offset = transform.position - target.transform.position;
        behind = offset;
        above = new Vector3(.11f, 8.27f, -7.57f);        
    }

    void LateUpdate()
    {
        RaycastHit hit;        
        if (Physics.Linecast(target.transform.position + behind, target.transform.position - new Vector3(0f, -1f, 1f))) {
            offset = above;
        } else {
            offset = behind;
        }

        Debug.DrawLine(target.transform.position + behind, target.transform.position - new Vector3(0f, -2f, 1f));
        
        Vector3 desiredPosition = target.transform.position + offset;
        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, Time.deltaTime * 10.0f);
        transform.LookAt(target.transform.position);
    }
}
