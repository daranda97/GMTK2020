using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_nav_enemy2_navigation_control : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;
    public float rot_speed;

    private float shot_stopwatch;
    public GameObject bullet_prefab;
    public GameObject end_of_barrel1;
    public GameObject end_of_barrel2;
    public GameObject end_of_barrel3;
    public float refire_time;
    public float firevelocity;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        shot_stopwatch = refire_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (Vector3.Distance(target.position, transform.position) < 50)
            {
                agent.SetDestination(target.position);


                shot_stopwatch += Time.deltaTime;

                if (shot_stopwatch >= refire_time)
                {
                    shoot();
                }

                Vector3 direction = target.position - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rot_speed * Time.deltaTime);

            }
            else
            {


                agent.SetDestination(transform.position);
                // add patroling code here if applicable
            }


        }


    }



    void shoot() {



        shot_stopwatch = 0;
        GameObject leftBullet = Instantiate(bullet_prefab);
        GameObject middleBullet = Instantiate(bullet_prefab);
        GameObject rightBullet = Instantiate(bullet_prefab);

        // Instatiate the left bullet to be fired.
        leftBullet.transform.position = end_of_barrel1.transform.position;
        leftBullet.transform.rotation = end_of_barrel1.transform.rotation;
        leftBullet.GetComponent<Rigidbody>().AddForce(leftBullet.transform.forward * firevelocity);

        // Instatiate the middle bullet to be fired.
        middleBullet.transform.position = end_of_barrel2.transform.position;
        middleBullet.transform.rotation = end_of_barrel2.transform.rotation;
        middleBullet.GetComponent<Rigidbody>().AddForce(middleBullet.transform.forward * firevelocity);

        // Instatiate the right bullet to be fired.
        rightBullet.transform.position = end_of_barrel3.transform.position;
        rightBullet.transform.rotation = end_of_barrel3.transform.rotation;
        rightBullet.GetComponent<Rigidbody>().AddForce(rightBullet.transform.forward * firevelocity);

    }
}