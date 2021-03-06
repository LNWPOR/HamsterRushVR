﻿using UnityEngine;
using System.Collections;

public class Swipes : MonoBehaviour
{
    public Transform palm;
    public float threshold = 0.02f;
    public float timeTreshold = 0.8f;
    public float swipingTimeLimit = 0.2f;
    public float swipingTimeCurrent = 0;
    private float timer = 0.0f;
    private float lastTime;
    private Vector3 lastPos;

    private bool handIsExtending = false;
    public bool HandIsExtending
    {
        get
        {
            return handIsExtending;
        }
        set
        {
            handIsExtending = value;
        }
    }

    private bool isSwipingRight = false;
    public bool IsSwipingRight
    {
        get
        {
            return isSwipingRight;
        }

        set
        {
            isSwipingRight = value;
        }
    }

    private bool isSwipingLeft = false;
    public bool IsSwipingLeft
    {
        get
        {
            return isSwipingLeft;
        }

        set
        {
            isSwipingLeft = value;
        }
    }

    private bool isSwipingUp = false;
    public bool IsSwipingUp
    {
        get
        {
            return isSwipingUp;
        }

        set
        {
            isSwipingUp = value;
        }
    }

    private bool isSwipingDown = false;
    public bool IsSwipingDown
    {
        get
        {
            return isSwipingDown;
        }

        set
        {
            isSwipingDown = value;
        }
    }

    void Start()
    {
        lastPos = palm.position;
        lastTime = timer;
    }

    void Update()
    {
        WaitSwiping();

        timer += Time.deltaTime;
        //update lastPos, lastTime
        if (timer - lastTime > timeTreshold)
        {
            lastPos = palm.position;
            lastTime = timer;
            //ResetSwipes();
        }
        else
        {
            //Check SwipeDir
            Vector3 offset = palm.position - lastPos;
            CheckSwipeDir(offset.x > threshold, "SWIPING_RIGHT") ;
            CheckSwipeDir(-offset.x > threshold, "SWIPING_LEFT");
            CheckSwipeDir(offset.y > threshold, "SWIPING_UP");
            CheckSwipeDir(-offset.y > threshold, "SWIPING_DOWN");
        }
    }

    private void WaitSwiping()
    {
        if (swipingTimeCurrent > 0)
        {
            swipingTimeCurrent -= Time.deltaTime;
        }
        else
        {
            isSwipingRight = false;
            isSwipingLeft = false;
            isSwipingUp = false;
            isSwipingDown = false;
        }
    }

    private void CheckSwipeDir(bool offsetResult, string swipingDir)
    {
        if (offsetResult && handIsExtending.Equals(true) )
        {
            if (swipingDir.Equals("SWIPING_RIGHT") && !isSwipingRight)
            {
                isSwipingRight = true;
                swipingTimeCurrent = swipingTimeLimit;
                //StartCoroutine(WaitSwiping(swipingTimeLimit, (i) => { isSwipingRight = i; }));
            }
            else if (swipingDir.Equals("SWIPING_LEFT") && !isSwipingLeft)
            {
                isSwipingLeft = true;
                swipingTimeCurrent = swipingTimeLimit;
                //StartCoroutine(WaitSwiping(swipingTimeLimit, (i) => { isSwipingLeft = i; }));
            }
            else if (swipingDir.Equals("SWIPING_UP") && !isSwipingUp)
            {
                isSwipingUp = true;
                swipingTimeCurrent = swipingTimeLimit;
                //StartCoroutine(WaitSwiping(swipingTimeLimit, (i) => { isSwipingUp = i; }));
            }
            else if (swipingDir.Equals("SWIPING_DOWN") && !isSwipingDown)
            {
                isSwipingDown = true;
                swipingTimeCurrent = swipingTimeLimit;
                //StartCoroutine(WaitSwiping(swipingTimeLimit, (i) => { isSwipingDown = i; }));
            }
        }
    }

    //private void ResetSwipes()
    //{
    //    isSwipingRight = false;
    //    isSwipingLeft = false;
    //    isSwipingUp = false;
    //    isSwipingDown = false;
    //}

    /*
    private IEnumerator WaitSwiping(float time, System.Action<bool> isSwipingDir)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }
        isSwipingDir(false);
    }
    */
}
