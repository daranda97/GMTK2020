using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_char_caharacter_rotation_control : MonoBehaviour
{
    public bool halt_mouse_control;

    RaycastHit hit;
    Ray ray;

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

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Vector3 direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                Quaternion toRotation = Quaternion.LookRotation(direction);
                character_box.transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, speed * Time.time);
            }
        }
    }
}
