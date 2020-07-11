using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_char_caharacter_rotation_control : MonoBehaviour
{
    Vector2 mouse_look;
    Vector2 Smoothing;
    public float rotation_sensitivity = 2f;
    public float smoothing_factor = 2f;
    public bool halt_mouse_control;
    public GameObject main_camera;

    RaycastHit hit;
    Ray ray;
    //*/


    public GameObject character_box;
    
    public float speed;

    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {


        if (!halt_mouse_control)
        {

            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {


                Vector3 direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(direction);
                character_box.transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.time);



            }




        }
    }
}
