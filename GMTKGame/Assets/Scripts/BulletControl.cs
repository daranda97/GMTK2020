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
        bullet = this.transform.parent.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (youngBullet)
        {
            bullet.GetComponent<Rigidbody>().AddForce(-bullet.transform.forward * velocity);
            float angle = Vector3.SignedAngle(transform.forward, target, transform.up) / 180f;
            bullet.transform.Rotate(transform.up, angle);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * velocity);
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
