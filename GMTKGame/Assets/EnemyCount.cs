using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    int numenemies;
    public TMP_Text count;
    // Start is called before the first frame update
    void Start()
    {
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
    }

}
