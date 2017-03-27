using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    public GameObject player;
    public PlayerScoreController playerScoreControllerScript;
    public float playerPreviousScore = 0;
    public float rangeChangeStage = 2000;
    private void Awake()
    {
        playerScoreControllerScript = player.GetComponent<PlayerScoreController>();
        playerPreviousScore = 0;
    }
    /*
    public int currentStageNumber;

    void Start () {
        currentStageNumber = 1;
	}

    public void ChangeStage(int stageNumber)
    {
        currentStageNumber = stageNumber;
        GameObject currentStageGenerator = transform.GetChild(stageNumber - 1).gameObject;
        currentStageGenerator.SetActive(true);
    }
	*/
}
