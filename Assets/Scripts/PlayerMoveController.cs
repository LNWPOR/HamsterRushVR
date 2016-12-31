using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveController : MonoBehaviour {

    public GameObject CapsuleHand_L;
    private Swipes CapsuleHandSwipes_L;
    public GameObject CapsuleHand_R;
    private Swipes CapsuleHandSwipes_R;

    //public float movingTimeLimit = 0.8f;
    //public float movingTimeCurrent = 0f;

    public float changeLaneTimerLimit = 0.8f;
    public float jumpTimerLimit = 1f;
    public float slideTimerLimit = 1f;

    public List<PlayerMoveData> moveList = new List<PlayerMoveData>();
    public PlayerMoveData moveRight;
    public PlayerMoveData moveLeft;
    public PlayerMoveData jump;
    public PlayerMoveData slide;

    public float playerStartSpeed = 2f;
    public float playerSpeed;

    private float newLanePosX;

    private Rigidbody playerRigidbody;

    void Awake()
    {
        CapsuleHandSwipes_L = CapsuleHand_L.GetComponent<Swipes>();
        CapsuleHandSwipes_R = CapsuleHand_R.GetComponent<Swipes>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    
    void Start () {
        InitMoveList();
        playerSpeed = playerStartSpeed;
    }
    private void InitMoveList()
    {
        moveRight = new PlayerMoveData("MoveRight", changeLaneTimerLimit);
        moveLeft = new PlayerMoveData("MoveLeft", changeLaneTimerLimit);
        jump = new PlayerMoveData("Jump", jumpTimerLimit);
        slide = new PlayerMoveData("Slide", slideTimerLimit);

        moveRight.InitOtherMoveStopList(new List<PlayerMoveData> { moveLeft });
        moveLeft.InitOtherMoveStopList(new List<PlayerMoveData> { moveRight });
        jump.InitOtherMoveStopList(new List<PlayerMoveData> { slide });
        slide.InitOtherMoveStopList(new List<PlayerMoveData> { jump });

        moveList.Add(moveRight);
        moveList.Add(moveLeft);
        moveList.Add(jump);
        moveList.Add(slide);
    }

    void Update () {
        Debug.Log(moveRight.canMove);
        MoveForward();
        WaitAllMovingTimer();
        CheckCanChangeLane();
        CheckMoveTrigger();
        CheckIsChangeLane();
        CheckIsJuming();
    }

    private void CheckIsJuming()
    {
        if (jump.isMoving)
        {
            playerRigidbody.AddForce(new Vector3(0, 20, 0));
        }
    }

    private void CheckCanChangeLane()
    {
        if (transform.position.x.Equals(1))
        {
            moveRight.canMove = false;
        }

        if (transform.position.x.Equals(-1))
        {
            moveLeft.canMove = false;
        }
    }

    private void CheckIsChangeLane()
    {
        if (moveRight.isMoving || moveLeft.isMoving)
        {
            ChangeLane(newLanePosX, changeLaneTimerLimit / (Mathf.Abs(transform.position.x - newLanePosX)));
        }
    }

    private void WaitAllMovingTimer()
    {
        foreach (PlayerMoveData move in moveList)
        {
            move.WaitMovingTimer();
        }
    }

    public void ChangeLane(float newLanePosX, float fracJourney)
    {
        Vector3 newLanePos = new Vector3(newLanePosX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newLanePos, fracJourney);
    }

    public void ChangeNewLanePosX(float addPosX)
    {
        newLanePosX += addPosX;
    }

    public void MoveForward()
    {
        Vector3 newPos = transform.position;
        newPos.z += Time.deltaTime * playerSpeed;
        transform.position = newPos;
    }

    private void CheckMoveTrigger()
    {
        if (CapsuleHandSwipes_L.IsSwipingRight && CapsuleHandSwipes_R.IsSwipingRight)
        {
            if (moveRight.canMove)
            {
                Debug.Log("MoveRight");
                ChangeNewLanePosX(1);
                moveRight.StartMoving();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingLeft && CapsuleHandSwipes_R.IsSwipingLeft)
        {
            if (moveLeft.canMove)
            {
                Debug.Log("MoveLeft");
                ChangeNewLanePosX(-1);
                moveLeft.StartMoving();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingUp && CapsuleHandSwipes_R.IsSwipingUp)
        {
            if (jump.canMove)
            {
                Debug.Log("Jump");
                jump.StartMoving();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingDown && CapsuleHandSwipes_R.IsSwipingDown)
        {
            if (slide.canMove)
            {
                Debug.Log("Slide");
                slide.StartMoving();
            }
        }
    }

    private void StopAllCanMove()
    {
        foreach (PlayerMoveData move in moveList)
        {
            move.StopCanMove();
        }
    }

    private void StartAllCanMove()
    {
        foreach (PlayerMoveData move in moveList)
        {
            move.StartCanMove();
        }
    }
}
