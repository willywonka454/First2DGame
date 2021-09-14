using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float switchTime;

    private float prevSwitch;

    private bool isDay = true;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        prevSwitch = Time.time;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float currTime = Time.time;

        if (currTime >= (prevSwitch + switchTime))
        {
            if (isDay)
            {
                isDay = false;
                anim.SetBool("Day", false);
                anim.SetBool("TransitionToNight", true);
            }
            else
            {
                isDay = true;
                anim.SetBool("Day", true);
                anim.SetBool("TransitionToDay", true);
            }
            prevSwitch = currTime;
        }
    }

    void TransitionToNightOver()
    {
        anim.SetBool("TransitionToNight", false);
    }

    void TransitionToDayOver()
    {
        anim.SetBool("TransitionToDay", false);
    }
}
