using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveData {
    public string name;
    public bool canMove = true;
    public bool isMoving = false;
    public float moveTimerLimit;
    public float moveTimerCurrent = 0f;

    public List<PlayerMoveData> otherMoveStopList;

    public PlayerMoveData(string newName, float newMoveTimerLimit)
    {
        name = newName;
        moveTimerLimit = newMoveTimerLimit;
    }

    public void InitOtherMoveStopList(List<PlayerMoveData> newOtherMoveStopList)
    {
        otherMoveStopList = newOtherMoveStopList;
    }

    public void StartMoving()
    {
        isMoving = true;
        StopCanMove();
        StartMoveTimer();
        StopOtherCanMove();
    }

    public void StopIsMoving()
    {
        isMoving = false;
    }

    public void StartMoveTimer()
    {
        moveTimerCurrent = moveTimerLimit;
    }

    public void StopCanMove()
    {
        canMove = false;
    }

    public void StartCanMove()
    {
        canMove = true;
        StopIsMoving();
    }

    public void WaitMovingTimer()
    {
        if (isMoving)
        {
            if (moveTimerCurrent > 0)
            {
                moveTimerCurrent -= Time.deltaTime;
            }
            else
            {
                StartCanMove();
                StartOtherCanMove();
            }
        }
    }

    public void StartOtherCanMove()
    {
        foreach (PlayerMoveData move in otherMoveStopList)
        {
            move.StartCanMove();
        }
    }

    public void StopOtherCanMove()
    {
        foreach (PlayerMoveData move in otherMoveStopList)
        {
            move.StopCanMove();
        }

    }
}
