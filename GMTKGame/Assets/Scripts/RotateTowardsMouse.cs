using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
