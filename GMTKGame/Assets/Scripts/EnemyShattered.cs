using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShattered : MonoBehaviour
{
    public float waittoshrinktime;
    public float shrinkspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waittoshrinktime -= Time.deltaTime;
        if (waittoshrinktime <= 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localScale = Vector3.MoveTowards(transform.GetChild(i).localScale, Vector3.zero, shrinkspeed * Time.deltaTime);
            }
            if (transform.GetChild(0).localScale.magnitude <= 0.05)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
