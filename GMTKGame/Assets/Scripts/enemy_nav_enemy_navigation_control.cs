using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_nav_enemy_navigation_control : MonoBehaviour
{
 public Transform target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position,agent.transform.position) < 50)
            agent.SetDestination(target.position);
    }


    void shoot() {


        // add shooty code here plz

    }
}
