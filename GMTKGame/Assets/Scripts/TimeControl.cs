using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float normaltime;
    public float slowtime;
    public float slowertime;
    public float changespeed;

    private bool decreasing;
    private float fixedDeltaTime;
    private float targetslow;
    private float currentchangespeed;


    private bool paused;
    private float ts;

    void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    /*public void Pause()
    {
        if (paused)
        {
            Time.timeScale = ts;
            Time.fixedDeltaTime = ts * fixedDeltaTime;
            paused = false;
        }
        else
        {
            paused = true;
            ts = Time.timeScale;
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        //if (!paused)
        //{
            if (decreasing)
            {
                if (Time.timeScale > targetslow)
                {
                    Time.timeScale -= currentchangespeed * Time.deltaTime;
                    Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
                }
                else
                    decreasing = false;
            }
            else
            {
                if (targetslow != slowertime)
                {
                    if (Time.timeScale < normaltime)
                    {
                        Time.timeScale += currentchangespeed * Time.deltaTime;
                        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
                    }
                    else
                    {
                        Time.timeScale = normaltime;
                        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
                    }
                }
            }
        //}
    }

    public void Trigger()
    {
        decreasing = true;
        targetslow = slowtime;
        currentchangespeed = changespeed;
    }

    public void Pause()
    {
        if (paused)
        {
            Time.timeScale = normaltime;
            Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
            paused = false;
        }
        else
        {
            decreasing = true;
            targetslow = slowertime;
            currentchangespeed = changespeed;
            paused = true;
        }
    }
}
