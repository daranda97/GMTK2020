using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingCone : MonoBehaviour
{
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
    }

    //Find closest
    public GameObject GetTarget(Transform startpos)
    {
        GameObject toreturn = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                if (Vector3.Distance(startpos.position, enemy.transform.position) < distance)
                {
                    toreturn = enemy;
                    distance = Vector3.Distance(startpos.position, enemy.transform.position);
                }
            }
        }

        return toreturn;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Enemy")
        {
            Debug.Log("See enemy");
            if (enemies.Contains(other.gameObject))
            {
                Debug.Log("Adding it");
                enemies.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemies.Contains(other.gameObject))
        {
            enemies.Remove(other.gameObject);
        }
    }
}
