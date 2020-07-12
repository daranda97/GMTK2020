using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour
{
    public GameObject shattered_enemy;
    public GameObject shattered_player;
    public GameObject enemycount;
    public GameObject menus;
    public bool youngBullet = true;

    private void Start()
    {
        enemycount = GameObject.Find("HUD/Panel/EnemyCount");
        menus = GameObject.Find("HUD");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!youngBullet)
        {
            //Will need to make the camera separate
            if (other.tag == "Player")
            {
                GameObject newshatter = Instantiate(shattered_player);
                newshatter.transform.position = other.transform.GetChild(0).GetChild(0).position;
                newshatter.transform.rotation = other.transform.GetChild(0).GetChild(0).rotation;
                Destroy(other.gameObject);
                menus.GetComponent<MenusControl>().OpenMenu(1);
            }
        }

        if (other.tag == "Enemy")
        {
            GameObject newshatter = Instantiate(shattered_enemy);
            newshatter.transform.position = other.transform.position;
            newshatter.transform.rotation = other.transform.rotation;
            Destroy(other.gameObject);
            enemycount.GetComponent<EnemyCount>().DecreaseCount();
        }
    }
}
