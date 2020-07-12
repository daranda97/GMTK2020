using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWallFlash : MonoBehaviour
{
    public GameObject prefab;
    public float alivetime;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newprefab = Instantiate(prefab);
        newprefab.transform.position = transform.position;
        newprefab.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        Destroy(newprefab, alivetime);
    }
}
