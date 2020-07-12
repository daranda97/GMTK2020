using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem_shot_control : MonoBehaviour
{

    private float shot_stopwatch;
    public GameObject bullet_prefab;
    public GameObject end_of_barrel;
    public float refire_time;
    public float firevelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        shot_stopwatch += Time.deltaTime;

        if (shot_stopwatch >= refire_time)
        {
            shot_stopwatch = 0;
            GameObject newbullet = Instantiate(bullet_prefab);
            newbullet.transform.position = end_of_barrel.transform.position;
            newbullet.transform.rotation = end_of_barrel.transform.rotation;

            newbullet.GetComponent<Rigidbody>().AddForce(newbullet.transform.forward * firevelocity);
        }

    }
}
