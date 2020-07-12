using System.Collections;
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
        if (fire_limiter) {
            
            counter++;
        }

        if (counter > 100) {
            fire_limiter = false;
            counter = 0;
            input_z = 0;


        }

        rotate(input_z);




    }


    void rotate(float targ) {


        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, targ), speed * Time.deltaTime);



    }

    public void enable_turn(float inpt) {

        input_z = inpt;
        fire_limiter = true;

    }

}
