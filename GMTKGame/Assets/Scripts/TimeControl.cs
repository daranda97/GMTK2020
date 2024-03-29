﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float normaltime;
    public float slowtime;
    public float slowertime;
    public float changespeed;

    private bool decreasing;
    public float fixedDeltaTime;
    private float targetslow;
    private float currentchangespeed;

    private bool dead;
    private bool paused;
    private float ts;

    void Awake()
    {
        Time.timeScale = normaltime;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    public void Pause()
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
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
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
                if (!dead)
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
        }
    }

    public void Trigger()
    {
        decreasing = true;
        targetslow = slowtime;
        currentchangespeed = changespeed;
    }

    public void Dead()
    {
        if (dead)
        {
            //Time.timeScale = normaltime;
            //Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
            dead = false;
        }
        else
        {
            decreasing = true;
            targetslow = slowertime;
            currentchangespeed = changespeed;
            dead = true;
        }
    }
}
