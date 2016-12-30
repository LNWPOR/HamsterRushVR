using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveController : MonoBehaviour {

    public GameObject CapsuleHand_L;
    private Swipes CapsuleHandSwipes_L;
    public GameObject CapsuleHand_R;
    private Swipes CapsuleHandSwipes_R;

    public float movingTimeLimit = 0.8f;
    public float movingTimeCurrent = 0f;

    public List<PlayerMoveData> moveList = new List<PlayerMoveData>();
    public PlayerMoveData moveRight = new PlayerMoveData("MoveRight");
    public PlayerMoveData moveLeft = new PlayerMoveData("MoveLeft");
    public PlayerMoveData jump = new PlayerMoveData("Jump");
    public PlayerMoveData slide = new PlayerMoveData("Slide");


    public float playerStartSpeed = 2f;
    public float playerSpeed;

    private float newLanePosX;

    void Awake()
    {
        CapsuleHandSwipes_L = CapsuleHand_L.GetComponent<Swipes>();
        CapsuleHandSwipes_R = CapsuleHand_R.GetComponent<Swipes>();
    }
    
    void Start () {
        InitMoveList();
        playerSpeed = playerStartSpeed;
    }
	
	void Update () {
        MoveForward();
        WaitMovingTime();
        CheckCanChangeLane();
        CheckMoveTrigger();
        CheckIsChangeLane();
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
            ChangeLane(newLanePosX, movingTimeLimit / (Mathf.Abs(transform.position.x - newLanePosX)));
        }
    }

    private void WaitMovingTime()
    {
        if (movingTimeCurrent > 0)
        {
            movingTimeCurrent -= Time.deltaTime;
        }
        else
        {
            CanMove();
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

    private void InitMoveList()
    {
        moveList.Add(moveRight);
        moveList.Add(moveLeft);
        moveList.Add(jump);
        moveList.Add(slide);
    }

    private void CheckMoveTrigger()
    {
        if (CapsuleHandSwipes_L.IsSwipingRight && CapsuleHandSwipes_R.IsSwipingRight)
        {
            if (moveRight.canMove)
            {
                Debug.Log("MoveRight");
                moveRight.isMoving = true;
                ChangeNewLanePosX(1);
                movingTimeCurrent = movingTimeLimit;
                StopMove();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingLeft && CapsuleHandSwipes_R.IsSwipingLeft)
        {
            if (moveLeft.canMove)
            {
                Debug.Log("MoveLeft");
                moveLeft.isMoving = true;
                ChangeNewLanePosX(-1);
                movingTimeCurrent = movingTimeLimit;
                StopMove();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingUp && CapsuleHandSwipes_R.IsSwipingUp)
        {
            if (jump.canMove)
            {
                Debug.Log("Jump");
                jump.isMoving = true;
                movingTimeCurrent = movingTimeLimit;
                StopMove();
            }
        }
        else if (CapsuleHandSwipes_L.IsSwipingDown && CapsuleHandSwipes_R.IsSwipingDown)
        {
            if (slide.canMove)
            {
                Debug.Log("Slide");
                slide.isMoving = true;
                movingTimeCurrent = movingTimeLimit;
                StopMove();
            }
        }
    }

    private void StopMove()
    {
        foreach (PlayerMoveData move in moveList)
        {
            move.canMove = false;
        }
    }

    private void CanMove()
    {
        foreach (PlayerMoveData move in moveList)
        {
            move.canMove = true;
            move.isMoving = false;
        }
    }
}
