using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGunController : MonoBehaviour
{
    [SerializeField] private GameObject wepInHand;
    [SerializeField] private GameObject wepOnGround;
    [SerializeField] private ParticleSystem overheat;
    [SerializeField] private Animator animator;

    private int gunBoolHash;

    public bool isInHand = false; //Used in ShootingController to test if the taser is in the player's hand
    public Rigidbody projectile;
    public float speed = 20;
    public float cooldown = 0;
    private Rigidbody instantiatedProjectile;
    private GameObject player;

    void Start()
    {
        wepInHand.SetActive(false);
        gunBoolHash = Animator.StringToHash("has_gun");
        animator.SetBool(gunBoolHash, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            wepInHand.SetActive(true);
            wepOnGround.SetActive(false);
            animator.SetBool(gunBoolHash, true);
            overheat.Clear();
        }
    }

    private void Update()
    {
        isInHand = !wepOnGround.activeSelf;
        if (Input.GetButtonDown("Fire1")) {
            shootGun();        
        }
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
    }

    private void shootGun()
    {
        if (isInHand && !wepOnGround.active && cooldown <= 0) {
            instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.transform.Rotate(90, 0, 0);
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            cooldown = 10.0f;
            overheat.Emit(1);
        }
    }
}