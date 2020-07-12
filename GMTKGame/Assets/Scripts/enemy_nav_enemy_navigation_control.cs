using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_nav_enemy_navigation_control : MonoBehaviour
{
 public Transform target;

    private NavMeshAgent agent;
    public float rot_speed;

    private float shot_stopwatch;
    public GameObject bullet_prefab;
    public GameObject end_of_barrel;
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
        if (Vector3.Distance(target.position, transform.position) < 50)
        {
            agent.SetDestination(target.position);

        }
        else {


            agent.SetDestination(transform.position);
            // add patroling code here if applicable
        }

        shot_stopwatch += Time.deltaTime;

        if (shot_stopwatch >= refire_time)
        {
            shoot();
        }

            Vector3 direction = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rot_speed * Time.deltaTime);


    }

    void Aim() {

        // play animation if applicaple




    }


    void shoot() {
        


            shot_stopwatch = 0;
            GameObject newbullet = Instantiate(bullet_prefab);
            newbullet.transform.position = end_of_barrel.transform.position;
            newbullet.transform.rotation = end_of_barrel.transform.rotation;

            newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * firevelocity);
            

        


    }
}
