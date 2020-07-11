﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour
{
    public bool killing;
    public GameObject shattered_enemy;
    public GameObject shattered_player;

    private void OnTriggerEnter(Collider other)
    {
        if (killing)
        {
            //Will need to make the camera separate
            /*if (other.tag == "Player")
            {
                GameObject newshatter = Instantiate(shattered_player);
                newshatter.transform.position = other.transform.position;
                newshatter.transform.rotation = other.transform.rotation;
                Destroy(other.gameObject);
            }*/
            if (other.tag == "Enemy")
            {
                GameObject newshatter = Instantiate(shattered_enemy);
                newshatter.transform.position = other.transform.position;
                newshatter.transform.rotation = other.transform.rotation;
                Destroy(other.gameObject);
            }
        }
    }
}
