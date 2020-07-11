using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject copter;
    void Start()
    {
        copter = this.transform.parent.gameObject;
    }

    void ShootBullet()
    {
        float angle = ShotAngle();
        //Shoot from copter gun at angle
    }

    void ShootRocket()
    {
        float angle = ShotAngle();
        //Shoot from copter gun at angle
    }

    float ShotAngle()
    {
        Vector3 startingPosition = copter.transform.position;
        Vector3 mouse = Input.mousePosition;
        float angle = Vector3.Angle(startingPosition, mouse);
        float lowerBound, upperBound;
        bool right = false;
        if (Random.Range(0, 2) == 0)
        {
            right = true;
        }

        if (startingPosition.x > mouse.x)
        {
            angle = 360 - angle;
        }

        if (right)
        {
            lowerBound = angle + 30;
            upperBound = lowerBound + 120;
        }
        else
        {
            upperBound = angle - 30;
            lowerBound = upperBound - 120;
        }
        return Random.Range(lowerBound, upperBound) % 360;
    }
}
