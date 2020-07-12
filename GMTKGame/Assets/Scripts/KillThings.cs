using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour
{
    public GameObject shattered_enemy;
    public GameObject shattered_player;
    public GameObject enemycount;
    public bool youngBullet = true;

    private TimeControl timecontrol;

    private void Start()
    {
        enemycount = GameObject.Find("HUD/Panel/EnemyCount");
        timecontrol = GameObject.Find("TimeControl").GetComponent<TimeControl>();
        youngBullet = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!youngBullet)
        {
            //Will need to make the camera separate
            if (other.tag == "Player")
            {
                timecontrol.Trigger();
                GameObject newshatter = Instantiate(shattered_player);
                newshatter.transform.position = other.transform.GetChild(0).GetChild(0).position;
                newshatter.transform.rotation = other.transform.GetChild(0).GetChild(0).rotation;
                Destroy(other.gameObject);
            }
        }

        if (other.tag == "Enemy")
        {
            timecontrol.Trigger();
            GameObject newshatter = Instantiate(shattered_enemy);
            newshatter.transform.position = other.transform.position;
            newshatter.transform.rotation = other.transform.rotation;
            Destroy(other.gameObject);
            enemycount.GetComponent<EnemyCount>().DecreaseCount();
        }
    }
}
