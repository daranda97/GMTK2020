﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 target;
    public GameObject enemy;
    


    // Update is called once per frame
    void Update()
    {
        //Update targeting information
        if ((enemy != null) && enemy.activeInHierarchy)
        {
            target = enemy.transform.position;
        }

        //in case of wanting to replace with regular bullets
        /*if (Vector3.Distance(target, rocket.transform.position) < cancelDistance)
        {
            //create 2 bullet that are not young in same place with slightly split trajectory (20 degree split) and same speed
            //delete this rocket

            return;
        }*/

        GetComponent<Rigidbody>().AddForce(-transform.forward * 120);
        transform.LookAt(target);
        GetComponent<Rigidbody>().AddForce(transform.forward * 190);

    }
}
