using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public GameObject CapsuleHand_L;
    private Swipes CapsuleHandSwipes_L;
    public GameObject CapsuleHand_R;
    private Swipes CapsuleHandSwipes_R;

    public float movingTimeLimit = 0.8f;
    public PlayerMoveData moveRight;
    public PlayerMoveData moveLeft;
    public PlayerMoveData moveUp;
    void Awake () {
        CapsuleHandSwipes_L = CapsuleHand_L.GetComponent<Swipes>();
        CapsuleHandSwipes_R = CapsuleHand_R.GetComponent<Swipes>();
    }

    void Start()
    {
        InitMoveList();
    }

    private void InitMoveList()
    {
        moveRight = new PlayerMoveData("MoveRight");
        moveLeft = new PlayerMoveData("MoveLeft");
        moveUp = new PlayerMoveData("MoveUp");

        moveRight.InitOtherMoveStopList(new List<PlayerMoveData> { moveLeft, moveUp});
        moveLeft.InitOtherMoveStopList(new List<PlayerMoveData> { moveRight, moveUp });
        moveUp.InitOtherMoveStopList(new List<PlayerMoveData> { moveRight, moveLeft });

        moveRight.InitTimerLimit(movingTimeLimit);
        moveLeft.InitTimerLimit(movingTimeLimit);
        moveUp.InitTimerLimit(movingTimeLimit);

    }
    void Update () {
        CheckMoveTrigger();
        WaitAllMovingTimer();
    }
    private void WaitAllMovingTimer()
    {
        moveRight.WaitMovingTimer();
        moveLeft.WaitMovingTimer();
        moveUp.WaitMovingTimer();
    }
    private void CheckMoveTrigger()
    {
        if (CapsuleHandSwipes_L.IsSwipingRight && CapsuleHandSwipes_R.IsSwipingRight)
        {
            if (!moveRight.isMoving && !moveRight.OtherMoveIsMoving())
            {
                moveRight.isMoving = true;
                moveRight.StartMoveTimer();
                Debug.Log("Ranking");
            }

        }
        else if (CapsuleHandSwipes_L.IsSwipingLeft && CapsuleHandSwipes_R.IsSwipingLeft)
        {
            if (!moveLeft.isMoving && !moveLeft.OtherMoveIsMoving())
            {
                moveLeft.isMoving = true;
                moveLeft.StartMoveTimer();
                Debug.Log("Menu");
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingUp && CapsuleHandSwipes_R.IsSwipingUp)
        {
            if (!moveUp.isMoving && !moveLeft.OtherMoveIsMoving())
            {
                moveUp.isMoving = true;
                moveUp.StartMoveTimer();
                SceneManager.LoadScene("GamePlay");
            }

        }
    }


}
