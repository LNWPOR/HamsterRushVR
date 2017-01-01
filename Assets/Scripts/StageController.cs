using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

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
	
}
