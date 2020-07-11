using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_rot_gunturret_control : MonoBehaviour
{

    public GameObject gun_turret;
    public bool trigger_control = false;
    public float input_z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (trigger_control) {
            Quaternion toRotation = new Quaternion(transform.rotation.x, transform.rotation.y, input_z, transform.rotation.w);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 100f * Time.deltaTime);

        }
    }
}
