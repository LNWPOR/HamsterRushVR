using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveController : MonoBehaviour {
    public Transform mainCamTransform;
    private Vector3 newMovePos;
    public float headCheckOffset;

    public float knockBackTimerLimit = 3f;
    public float slidingSmooth = 0.05f;

    public List<PlayerMoveData> moveList = new List<PlayerMoveData>();
    public PlayerMoveData moveForward;
    public PlayerMoveData jump;
    public PlayerMoveData slide;
    public PlayerMoveData knockBack;
    public bool canJump = true;
    public bool canSlide = true;
    public bool canMoveUD = false;

    public float playerStartSpeed = 5f;
    public float playerCurrentSpeed;
    public float playerSpeedLimit = 20f;
    public float playerSpeedUpPercent = 1.2f;
    private float playerPreviousSpeed;

    private Rigidbody playerRigidbody;
    private bool isGrounded;
    public float jumpPower = 5f;

    private float playerPreviousScore = 0f;
    public float rangeScoreSpeedUp = 200f;

    private float maxSlope = 90f;
    
    public float moveLRSmooth;

    private float normalHeight;
    public float slideHeight;

    private AudioSource playerAS;
    public AudioClip jumpAudio;
    public AudioClip knockBackAudio;

    public CheckCollider leftCollider;
    public CheckCollider rightCollider;
    public CheckCollider upCollider;
    public CheckCollider downCollider;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        InitMoveList();
        moveForward.isMoving = true;
        playerCurrentSpeed = playerStartSpeed;
        playerPreviousSpeed = playerStartSpeed;
        normalHeight = GetComponent<CapsuleCollider>().height;
        playerAS = GetComponent<AudioSource>();
    }
    void Update()
    {
        /*
        //for testing in LeapMotion Mode
        float moveLRSentivity = 5f;
        float rotateX = Input.GetAxis("Mouse X") * moveLRSentivity;
        float rotateY = Input.GetAxis("Mouse Y") * moveLRSentivity;
        transform.Rotate(0,rotateX,0);
        mainCamTransform.Rotate(-rotateY,0,0);
        */

        //Debug.DrawLine(transform.position, mainCamTransform.forward * 50f, Color.green);
        
        CheckMoveTrigger();
    }
    void FixedUpdate()
    {
        newMovePos = transform.position + mainCamTransform.forward * 50f;
        MoveForward();
        MoveLR();
        if (canMoveUD)
        {
            MoveUD();
        }
    }
    void MoveUD()
    {
        if ((upCollider.isCollided && newMovePos.y > transform.position.y) ||
            (downCollider.isCollided && newMovePos.y < transform.position.y))
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
        }
        else
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x,
                                               (newMovePos.y - transform.position.y) * moveLRSmooth,
                                                playerRigidbody.velocity.z);
        }
        
    }
    void MoveLR()
    {
        CheckHeadFacing();
        //CheckHeadRotate();
    }
    private void CheckHeadFacing()
    {
        if ((leftCollider.isCollided && newMovePos.x < transform.position.x) || 
            (rightCollider.isCollided && newMovePos.x > transform.position.x))
        {
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        }
        else
        {
            playerRigidbody.velocity = new Vector3((newMovePos.x - transform.position.x) * moveLRSmooth,
                                                           playerRigidbody.velocity.y,
                                                           playerRigidbody.velocity.z);
        }
        
    }
    private void CheckHeadRotate()
    {
        playerRigidbody.velocity = new Vector3(mainCamTransform.rotation.z * 100 * moveLRSmooth,
                                                playerRigidbody.velocity.y,
                                                playerRigidbody.velocity.z);
    }
    public void MoveForward()
    {
        if (!moveForward.OtherMoveIsMoving())
        {
            moveForward.isMoving = true;
            float playerCurrentScore = GetComponent<PlayerScoreController>().playerCurrentScore;
            if ((playerCurrentScore - playerPreviousScore).Equals(rangeScoreSpeedUp))
            {
                playerPreviousScore += rangeScoreSpeedUp;
                if (playerCurrentSpeed * playerSpeedUpPercent > playerSpeedLimit)
                {
                    playerCurrentSpeed = playerSpeedLimit;
                }
                else
                {
                    playerCurrentSpeed *= playerSpeedUpPercent;
                }
            }
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y, playerCurrentSpeed);
        }
    }
    private void InitMoveList()
    {
        moveForward = new PlayerMoveData("MoveForward");
        jump = new PlayerMoveData("Jump");
        slide = new PlayerMoveData("Slide");
        knockBack = new PlayerMoveData("KnockBack");

        moveForward.InitOtherMoveStopList(new List<PlayerMoveData> { knockBack });
        jump.InitOtherMoveStopList(new List<PlayerMoveData> { slide });
        slide.InitOtherMoveStopList(new List<PlayerMoveData> { jump });

        moveList.Add(moveForward);
        moveList.Add(jump);
        moveList.Add(slide);
        moveList.Add(knockBack);
    }
    private void CheckMoveTrigger()
    {
        if (canJump)
        {
            JumpListener();
        }
        if (canSlide)
        {
            //SlideListener();
        }
    }
    void JumpListener()
    {
        if (newMovePos.y > mainCamTransform.position.y + headCheckOffset)
        {
            if (isGrounded && !jump.OtherMoveIsMoving())
            {
                //Debug.Log("Jump");
                playerRigidbody.velocity = new Vector3(0, jumpPower, 0);
                jump.isMoving = true;
                playerPreviousSpeed = playerCurrentSpeed;
                playerCurrentSpeed = playerStartSpeed;
                playerAS.PlayOneShot(jumpAudio);
            }else
            {
                jump.isMoving = false;
            }

        }
    }
    void SlideListener()
    {
        if (newMovePos.y < mainCamTransform.position.y - headCheckOffset)
        {
            if (isGrounded && !slide.OtherMoveIsMoving())
            {
                //Debug.Log("Slide");
                slide.isMoving = true;
                GetComponent<CapsuleCollider>().height = Mathf.Lerp(GetComponent<CapsuleCollider>().height, slideHeight, slidingSmooth);
            }
        }
        else
        {
            slide.isMoving = false;
            GetComponent<CapsuleCollider>().height = Mathf.Lerp(GetComponent<CapsuleCollider>().height, normalHeight, slidingSmooth);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts )
        {
            if (Vector3.Angle(contact.normal,Vector3.up) < maxSlope)
            {
                isGrounded = true;
            }
        }
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    public IEnumerator KnockBack()
    {
        knockBack.isMoving = true;
        Vector3 newPos = new Vector3(0, 2, transform.position.z - 6);
        transform.position = newPos;
        playerRigidbody.velocity = Vector3.zero;
        playerCurrentSpeed = playerStartSpeed;
        playerAS.PlayOneShot(knockBackAudio);
        yield return new WaitForSeconds(knockBackTimerLimit);
        knockBack.isMoving = false;   
    }
    public void MoveSetChange(bool newCanJump, bool newCanSlide, bool newCanMoveUD)
    {
        canJump = newCanJump;
        canSlide = newCanSlide;
        canMoveUD = newCanMoveUD;
    }
}
