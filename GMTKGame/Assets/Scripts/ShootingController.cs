using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    public TargetingCone targetingCone;
    public GameObject bullet_prefab;
    public GameObject end_of_barrel;
    public Turret_rot_gunturret_control turret;
    public float nofireangle;
    public float fireangle;
    public float firevelocity;
    public float refire_time;

    private float shot_stopwatch;

    void Start()
    {
        shot_stopwatch = refire_time;
    }

    private void Update()
    {
        shot_stopwatch += Time.deltaTime;

        if (Input.GetAxis("Fire1") != 0 && shot_stopwatch >= refire_time)
        {
            shot_stopwatch = 0;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        //Transform target = targetingCone.GetTarget(this.transform).transform;

        GameObject newbullet = Instantiate(bullet_prefab);
        newbullet.transform.position = end_of_barrel.transform.position;
        newbullet.transform.rotation = end_of_barrel.transform.rotation;

        float angle;
        if (Random.Range(0f, 1f) > 0.5f)
            angle = Random.Range(nofireangle, fireangle);
        else
            angle = -Random.Range(nofireangle, fireangle);

        turret.input_z = angle;

        newbullet.transform.Rotate(transform.up, angle);

        newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * firevelocity);

        //Maybe add stuff about setting the target velocity
        //newbullet.GetComponent<BulletControl>()
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
