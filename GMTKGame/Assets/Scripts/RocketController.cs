using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 target;
    public GameObject bullet_prefab;
    public GameObject enemy;
    public float time = 0;
    private bool flag = true;
    public float velocity;

    private void Start()
    {
        GetComponentInChildren<KillThings>().youngBullet = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(flag && time > 1.0f)
        {
            GetComponentInChildren<KillThings>().youngBullet = false;
            flag = false;
        }
        //Update targeting information
        if ((enemy != null) && enemy.activeInHierarchy)
        {
            target = enemy.transform.position;
        }

        //in case of wanting to replace with regular bullets
        if (time > 4.0f)
        {
            Object.Destroy(this.gameObject);
            GameObject newbullet1 = Instantiate(bullet_prefab);
            GameObject newbullet2 = Instantiate(bullet_prefab);
            newbullet1.GetComponentInChildren<KillThings>().youngBullet = false;
            newbullet2.GetComponentInChildren<KillThings>().youngBullet = false;
            newbullet1.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
            newbullet1.transform.forward = transform.forward;
            newbullet2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
            newbullet2.transform.forward = transform.forward;
            newbullet1.transform.Rotate(transform.up, 45);
            newbullet2.transform.Rotate(transform.up, -45);
            newbullet1.GetComponent<Rigidbody>().AddForce(newbullet1.transform.forward * velocity);
            newbullet2.GetComponent<Rigidbody>().AddForce(newbullet2.transform.forward * velocity);
            return;
        }

        GetComponent<Rigidbody>().AddForce(-transform.forward * 140);
        transform.LookAt(target);
        GetComponent<Rigidbody>().AddForce(transform.forward * 180);
    }
}
