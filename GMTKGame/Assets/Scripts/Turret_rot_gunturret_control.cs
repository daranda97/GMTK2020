﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_rot_gunturret_control : MonoBehaviour
{
    public float input_z;
    public float speed;
    public int counter;
    public bool fire_limiter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


       
            
            

       

        
    }


    void rotate() {


        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, input_z), speed * Time.deltaTime);



    }

}
