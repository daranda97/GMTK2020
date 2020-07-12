using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public TargetingCone targetingCone;
    public GameObject bullet_prefab;
    public GameObject end_of_barrel;
    public Turret_rot_gunturret_control turret;
    public float nofireangle;
    public float fireangle;
    public float firevelocity;
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

        turret.input_z = angle;

        newbullet.transform.Rotate(transform.up, angle);

        newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * firevelocity);

        newbullet.GetComponent<BulletControl>().target = target;
        newbullet.GetComponent<BulletControl>().youngBullet = true;
        newbullet.GetComponent<BulletControl>().velocity = firevelocity;
        newbullet.GetComponentInChildren<KillThings>().youngBullet = true;
    }

    /*void ShootRocket()
    {
        float angle = ShotAngle();
        GameObject enemy;

        if(enemies.Count > 0)
        {
            enemy = getRocketTarget();
            //Shoot from copter gun the same, but pass in enemy rather than target
        }
        Vector3 target = Input.mousePosition;
        //Shoot from copter gun at angle with target
    }*/
}
