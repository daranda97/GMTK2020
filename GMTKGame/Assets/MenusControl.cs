using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenusControl : MonoBehaviour
{
    public GameObject timecontrol;
    public GameObject win_screen;
    public GameObject lose_screen;
    public GameObject pause_screen;
    private bool pause_isopen = true;

    // Start is called before the first frame update
    void Start()
    {
        timecontrol = GameObject.Find("TimeControl");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            OpenMenu(2);
        }
    }

    public void OpenMenu(int menu)
    {
        if (menu != 2)
            timecontrol.GetComponent<TimeControl>().Dead();
        switch (menu)
        {
            case 0:                 //Winner Screen
                win_screen.SetActive(true);
                break;
            case 1:                 //Loser Screen
                lose_screen.SetActive(true);
                break;
            case 2:                 //Pause Menu
                timecontrol.GetComponent<TimeControl>().Pause();
                pause_screen.SetActive(true);
                break;
        }

    }

    
}
