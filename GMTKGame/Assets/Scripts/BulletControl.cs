﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Vector3 target;
    public bool youngBullet;
    public float velocity;


    private void OnCollisionEnter(Collision collision)
    {
        if (youngBullet)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            transform.LookAt(target);
            GetComponent<Rigidbody>().AddForce(transform.forward * velocity);
            youngBullet = false;
            GetComponentInChildren<KillThings>().youngBullet = false;
        }
    }
}
