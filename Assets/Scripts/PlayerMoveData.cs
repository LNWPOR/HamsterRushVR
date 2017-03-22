using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveData {
    public string name;
    public bool isMoving = false;
    public float moveTimerLimit;
    public float moveTimerCurrent = 0f;

    public List<PlayerMoveData> otherMovingCheckList;

    public PlayerMoveData(string newName)
    {
        name = newName;
    }
    public void InitOtherMoveStopList(List<PlayerMoveData> newOtherMovingCheckList)
    {
        otherMovingCheckList = newOtherMovingCheckList;
    }
    /*
    public void InitTimerLimit(float newMoveTimerLimit)
    {
        moveTimerLimit = newMoveTimerLimit;
    }
    public void StartMoveTimer()
    {
        moveTimerCurrent = moveTimerLimit;
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
                isMoving = false;
            }
        }
    }
    */

    public bool OtherMoveIsMoving()
    {
        int count = 0;
        foreach (PlayerMoveData move in otherMovingCheckList)
        {
            if (move.isMoving.Equals(true))
            {
                count += 1;
            }
        }
        return count.Equals(otherMovingCheckList.Count);
    }
}
