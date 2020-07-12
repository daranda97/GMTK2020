using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Vector3 target;
    public bool youngBullet;
    private GameObject bullet;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (youngBullet)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            transform.LookAt(target);
            GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
            youngBullet = false;
        }
    }

    //This will go elsewhere.
    /*void Hit(GameObject victim)
    {
        if (victim.tag == "player" && !youngBullet)
        {
            //kill player
        }
        else if (victim.tag == "enemy")
        {
            //kill enemy
        }
    }*/
}
