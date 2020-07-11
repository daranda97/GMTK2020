using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    enum Bullet
    {
        bullet,
        rocket
    }
    Vector3 target;
    bool youngBullet;
    float direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void HitWall()
    {
        if(youngBullet)
        {
            if (/*Trace toward wall hits wall within 0.1*/true)
            {
                //direction = target;
            }
            youngBullet = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
