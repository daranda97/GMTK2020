using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_control : MonoBehaviour
{


    public float move_speed;
    CharacterController cr;

    // Start is called before the first frame update
    void Start()
    {
        cr = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cr.Move(move * Time.deltaTime * move_speed);

        /*float horizontal_in = Input.GetAxis("Horizontal") * move_speed * Time.deltaTime;
        float vertical_in = Input.GetAxis("Vertical") * move_speed * Time.deltaTime;

        Vector3 move_forward = transform.forward * vertical_in;
        Vector3 move_sideways = transform.right * horizontal_in;
        Debug.Log(move_forward + move_sideways);
        cr.SimpleMove(move_forward + move_sideways);*/
    }
}
