using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public GameObject alttext;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("text");

        if (objs.Length > 1)
        {
            foreach (GameObject text in objs)
            {
                text.GetComponent<TextScript>().alttext.SetActive(true);
            }
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
