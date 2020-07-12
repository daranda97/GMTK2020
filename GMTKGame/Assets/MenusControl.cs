using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenusControl : MonoBehaviour
{
    public GameObject timecontrol;
    public GameObject win_screen;
    public GameObject lose_screen;
    //public GameObject pause_screen;

    // Start is called before the first frame update
    void Start()
    {
        timecontrol = GameObject.Find("TimeControl");
    }

    public void OpenMenu(int menu)
    {
        timecontrol.GetComponent<TimeControl>().Pause();
        switch (menu)
        {
            case 0:                 //Winner Screen
                win_screen.SetActive(true);
                break;
            case 1:                 //Loser Screen
                lose_screen.SetActive(true);
                break;
            case 2:                 //Pause Menu
                break;
        }

    }

    
}
