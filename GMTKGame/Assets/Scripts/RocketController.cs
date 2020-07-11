using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    GameObject rocket;
    Vector3 target;
    bool youngRocket;
    float direction;
    float cancelDistance = (float) 0.5;
    float angleChange = (float)0.01;
    // Start is called before the first frame update
    void Start()
    {
        rocket = this.transform.parent.gameObject;
        youngRocket = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (youngRocket)
        {
            if(Vector3.Distance(target, rocket.transform.position) < cancelDistance)
            {
                youngRocket = false;
                return;
            }
            float angle = Vector3.Angle(this.transform.position, target);
            if (rocket.transform.position.x > target.x)
            {
                angle = (360 - angle);
            }
            if (direction < angle && direction + 180 < angle)
            {
                direction = (direction - (angle * angleChange)) % 360;
                //change actual direction
                return;
            }
            else
            {
                direction = (direction + (angle * angleChange)) % 360;
                //change actual direction
                return;
            }
        }
    }
}
