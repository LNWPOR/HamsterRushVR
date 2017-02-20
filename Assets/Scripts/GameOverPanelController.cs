using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour {

    private GameObject player;
    public Text scoresText;
    public Text seedsText;

    public GameObject CapsuleHand_R_LM;
    public GameObject CapsuleHand_L_LM;
    public GameObject CapsuleHand_R_VR;
    public GameObject CapsuleHand_L_VR;
    private Swipes CapsuleHandSwipes_R;
    private Swipes CapsuleHandSwipes_L;
    private bool isVRmode;

    public float movingTimeLimit = 0.8f;
    public PlayerMoveData moveDown;
    public PlayerMoveData moveUp;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isVRmode = player.GetComponent<PlayerMoveController>().isVRmode;
        InitCapsuleHand();
    }

    void Start () {
        scoresText.text = player.GetComponent<PlayerScoreController>().playerCurrentScore.ToString();
        seedsText.text = player.GetComponent<PlayerSeedController>().playerCurrentSeed.ToString();
        InitMoveList();

    }
    private void InitMoveList()
    {
        moveUp = new PlayerMoveData("MoveUp");
        moveDown = new PlayerMoveData("MoveDown");

        moveUp.InitOtherMoveStopList(new List<PlayerMoveData> { moveDown });
        moveDown.InitOtherMoveStopList(new List<PlayerMoveData> { moveUp });

        moveUp.InitTimerLimit(movingTimeLimit);
        moveDown.InitTimerLimit(movingTimeLimit);
    }

    private void InitCapsuleHand()
    {
        if (isVRmode)
        {
            CapsuleHandSwipes_L = CapsuleHand_L_VR.GetComponent<Swipes>();
            CapsuleHandSwipes_R = CapsuleHand_R_VR.GetComponent<Swipes>();
        }
        else
        {
            CapsuleHandSwipes_L = CapsuleHand_L_LM.GetComponent<Swipes>();
            CapsuleHandSwipes_R = CapsuleHand_R_LM.GetComponent<Swipes>();
        }
    }

    void Update () {
        CheckMoveTrigger();
        WaitAllMovingTimer();
    }
    private void WaitAllMovingTimer()
    {
        moveUp.WaitMovingTimer();
    }
    private void CheckMoveTrigger()
    {
        if (CapsuleHandSwipes_L.IsSwipingUp && CapsuleHandSwipes_R.IsSwipingUp)
        {
            if (!moveUp.isMoving && !moveUp.OtherMoveIsMoving())
            {
                moveUp.isMoving = true;
                moveUp.StartMoveTimer();
                Debug.Log("MoveUp");
                SceneManager.LoadScene("GamePlay");
            }

        }
        else if (CapsuleHandSwipes_L.IsSwipingDown && CapsuleHandSwipes_R.IsSwipingDown)
        {
            if (!moveDown.isMoving && !moveDown.OtherMoveIsMoving())
            {
                moveDown.isMoving = true;
                moveDown.StartMoveTimer();
                Debug.Log("MoveDown");
            }

        }
    }
}
