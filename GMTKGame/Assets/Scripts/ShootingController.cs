﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public TargetingCone targetingCone;
    public GameObject bullet_prefab;
    public GameObject rocket_prefab;
    public GameObject end_of_barrel;
    public Turret_rot_gunturret_control turret;
    public float nofireangle;
    public float fireangle;
    public float firevelocity;
    public float slow = 1000;
    public float normal = 2000;
    public float fast = 3000;
    public float refire_time;

    public GameObject canfireobject;
    public GameObject nofireobject;

    private float shot_stopwatch;


    void Start()
    {
        shot_stopwatch = refire_time;
    }

    private void Update()
    {
        shot_stopwatch += Time.deltaTime;
        if (shot_stopwatch >= refire_time)
        {
            canfireobject.SetActive(true);
            nofireobject.SetActive(false);
        }
        else
        {
            canfireobject.SetActive(false);
            nofireobject.SetActive(true);
        }

        if (Input.GetAxis("Fire1") != 0 && shot_stopwatch >= refire_time)
        {
            shot_stopwatch = 0;
            ShootBullet();
        }

        if(Input.GetAxis("Fire2") != 0 && shot_stopwatch >= refire_time)
        {
            shot_stopwatch = 0;
            ShootRocket();
        }
    }

    void ShootBullet()
    {
        Vector3 target = new Vector3(0, transform.position.y, 0);
        try
        {
            target = targetingCone.GetTarget(this.transform).transform.position;
        }
        catch (NullReferenceException)
        {
            RaycastHit hit;
            Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }
        GameObject newbullet = Instantiate(bullet_prefab);
        newbullet.transform.position = end_of_barrel.transform.position;
        newbullet.transform.rotation = end_of_barrel.transform.rotation;

        float angle;
        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
            angle = UnityEngine.Random.Range(nofireangle, fireangle);
        else
            angle = -UnityEngine.Random.Range(nofireangle, fireangle);

        turret.GetComponent<Turret_rot_gunturret_control>().enable_turn(angle);

        newbullet.transform.Rotate(transform.up, angle);

        newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * firevelocity);

        newbullet.GetComponent<BulletControl>().target = target;
        newbullet.GetComponent<BulletControl>().youngBullet = true;
        newbullet.GetComponent<BulletControl>().velocity = firevelocity;
        newbullet.GetComponentInChildren<KillThings>().youngBullet = true;
    }

    void ShootRocket()
    {
        GameObject objectTarget = targetingCone.GetTarget(this.transform);
        Vector3 vectorTarget = new Vector3 { };
        if(objectTarget == null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                vectorTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
        }
        GameObject newrocket = Instantiate(rocket_prefab);
        newrocket.transform.position = end_of_barrel.transform.position;
        newrocket.transform.rotation = end_of_barrel.transform.rotation;

        float angle;
        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
            angle = UnityEngine.Random.Range(nofireangle, fireangle);
        else
            angle = -UnityEngine.Random.Range(nofireangle, fireangle);

        turret.GetComponent<Turret_rot_gunturret_control>().enable_turn(angle);

        newrocket.transform.Rotate(transform.up, angle);

        newrocket.GetComponent<Rigidbody>().AddForce(newrocket.transform.forward * firevelocity);
        
        newrocket.GetComponent<RocketController>().target = vectorTarget;
        newrocket.GetComponent<RocketController>().enemy = objectTarget;
        newrocket.GetComponent<RocketController>().velocity = firevelocity;
        newrocket.GetComponentInChildren<KillThings>().youngBullet = true;
    }

    public void setSlowVelocity()
    {
        firevelocity = slow;
    }

    public void setNormalVelocity()
    {
        firevelocity = normal;
    }

    public void setFastVelocity()
    {
        firevelocity = fast;
    }
}
