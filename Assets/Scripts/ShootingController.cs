//css_import StunGunController;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 20;
    public int cooldown = 10;

    // Update is called once per frame
    void Update()
    {
        //if(GameObject.Find("Taser").GetComponent<StunGunController>().isInHand == true) //Used to test if the taser is in the player's hand before allowing shooting
        //{
            if (Input.GetButtonDown("Fire1"))
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.transform.Rotate(90, 0, 0, Space.Self);
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            }
        //}
    }
}
