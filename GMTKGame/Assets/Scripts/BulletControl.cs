using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Vector3 target;
    bool youngBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    void HitWall()
    {
        if (youngBullet)
        {
            if (/*Trace toward wall does not hit wall within 0.1*/true)
            {
                //change course directly to target
            }
            youngBullet = false;
        }
    }

    void Hit(GameObject victim)
    {
        if (victim.tag == "player" && !youngBullet)
        {
            //kill player
        }
        else if (victim.tag == "enemy")
        {
            //kill enemy
        }
    }
}
