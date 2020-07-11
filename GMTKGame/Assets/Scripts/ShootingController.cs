using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject copter;
    GameObject targetingCone;
    List<GameObject> enemies;
    void Start()
    {
        copter = this.transform.parent.gameObject;
    }

    void ShootBullet()
    {
        float angle = ShotAngle();
        Vector3 target = getBulletTarget();
        //Shoot from copter gun at angle
    }

    void ShootRocket()
    {
        float angle = ShotAngle();
        GameObject enemy;

        if(enemies.Count > 0)
        {
            enemy = getRocketTarget();
            //Shoot from copter gun the same, but pass in enemy rather than target
        }
        Vector3 target = Input.mousePosition;
        //Shoot from copter gun at angle with target
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

    void DetectEnemy(GameObject other)
    {
        if(other.tag == "enemy")
        {
            enemies.Add(other);
        }
    }

    void LoseEnemy(GameObject other)
    {
        if(other.tag == "enemy")
        {
            if(enemies.Contains(other))
            {
                enemies.Remove(other);
            }
        }
    }

    Vector3 getBulletTarget()
    {
        if(enemies.Count > 0)
        {
            float smallestDistance = 0, newDistance;
            GameObject selectedObject = null;
            foreach(GameObject enemy in enemies)
            {
                newDistance = Vector3.Distance(enemy.transform.position, copter.transform.position);
                if (smallestDistance == 0)
                {
                    smallestDistance = newDistance;
                    selectedObject = enemy;
                }
                else if(smallestDistance > newDistance)
                {
                    smallestDistance = newDistance;
                    selectedObject = enemy;
                }
            }
            return selectedObject.transform.position;
        }
        else
        {
            return Input.mousePosition;
        }
    }

    GameObject getRocketTarget()
    {
        float smallestDistance = 0, newDistance;
        GameObject selectedObject = null;
        foreach (GameObject enemy in enemies)
        {
            newDistance = Vector3.Distance(enemy.transform.position, copter.transform.position);
            if (smallestDistance == 0)
            {
                smallestDistance = newDistance;
                selectedObject = enemy;
            }
            else if (smallestDistance > newDistance)
            {
                smallestDistance = newDistance;
                selectedObject = enemy;
            }
        }
        return selectedObject;
    }
}
