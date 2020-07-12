using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    //public GameObject timecontrol;
    public GameObject menuscontrol;
    int numenemies;
    public TMP_Text count;
    //public GameObject WinnerScreen;
    // Start is called before the first frame update
    void Start()
    {
        //timecontrol = GameObject.Find("TimeControl");
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
        }
        numenemies = enemies.Count;
        count.text = numenemies.ToString();
        enemies.Clear();
    }

    public void DecreaseCount()
    {
        numenemies--;
        count.text = numenemies.ToString();
        if (numenemies == 0)
        {
            menuscontrol.GetComponent<MenusControl>().OpenMenu(0);
        }
    }

}
