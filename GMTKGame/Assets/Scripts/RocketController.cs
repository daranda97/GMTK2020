using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject rocket;
    public Vector3 target;
    public GameObject enemy = null;
    bool isTrackingEnemy;
    float direction;
    public float cancelDistance = 0.5f;
    public float angleChange = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        rocket = this.transform.parent.gameObject;
        if(enemy == null)
        {
            isTrackingEnemy = false;
        }
        else
        {
            isTrackingEnemy = true;
            target = enemy.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update targeting information
        if(isTrackingEnemy && enemy.activeInHierarchy)
        {
            target = enemy.transform.position;
        }

        if (Vector3.Distance(target, rocket.transform.position) < cancelDistance)
        {
            //create 2 bullet that is not young in same place with slightly split trajectory (20 degree split) and same speed
            //delete this rocket

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
