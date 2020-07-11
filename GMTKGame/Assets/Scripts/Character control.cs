using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontrol : MonoBehaviour
{



    public float move_speed;
    public bool move_lock;
    CharacterController cr;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Move()
    {

        float horizontal_in = Input.GetAxis("Horizontal") * move_speed;
        float vertical_in = Input.GetAxis("Vertical") * move_speed;

        Vector3 move_forward = transform.forward * vertical_in;
        Vector3 move_sideways = transform.right * horizontal_in;

        cr.SimpleMove(move_forward + move_sideways);


    }




}
