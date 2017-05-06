using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPatternGenerator : MonoBehaviour {

    private GameObject stageController;
    private StageController stageControllerScript;
    public GameObject[] currentStagePatterns;
    public GameObject[] nextStatePatterns;
    public GameObject currentPattern;
    private PatternController currentPatternControllerScript;
    private void Awake()
    {
        currentPatternControllerScript = currentPattern.GetComponent<PatternController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            stageController = transform.parent.parent.gameObject;
            stageControllerScript = stageController.GetComponent<StageController>();
            if (stageControllerScript.playerScoreControllerScript.playerCurrentScore - stageControllerScript.playerPreviousScore >= stageControllerScript.rangeChangeStage)
            {
                stageControllerScript.playerPreviousScore += stageControllerScript.rangeChangeStage;
                InitNextPattern(nextStatePatterns);
            }
            else
            {
                InitNextPattern(currentStagePatterns);
            }
            Destroy(gameObject);
        }
    }
    private void InitNextPattern(GameObject[] patterns)
    {
        int nextPatternIndex = (int)Mathf.Round(Random.Range(0, patterns.Length - 1));
        PatternController nextPatternControlerScript = patterns[nextPatternIndex].GetComponent<PatternController>();
        Vector3 newPatternPoint = new Vector3(0, 0, 
            currentPatternControllerScript.currentPatternWidthRef.GetComponent<MeshRenderer>().bounds.size.z / 2 +
            nextPatternControlerScript.currentPatternWidthRef.GetComponent<MeshRenderer>().bounds.size.z / 2 +
            currentPatternControllerScript.currentPatternWidthRef.position.z);
        GameObject newGeneratePattern = Instantiate(patterns[nextPatternIndex], newPatternPoint, Quaternion.identity) as GameObject;
        newGeneratePattern.transform.parent = stageController.transform;
        newGeneratePattern.name = patterns[nextPatternIndex].gameObject.name;
        Transform currentPattern = transform.parent;
        if (!currentPattern.Equals(stageController.transform.GetChild(0)))
        {
            Destroy(stageController.transform.GetChild(0).gameObject);
        }
    }

    /*
    public GameObject[] patterns;
    public Transform currentPlaneRef;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            int nextPatternIndex = (int)Mathf.Round(Random.Range(0, patterns.Length));
            Transform stage = transform.parent.parent;
            Transform currentPattern = transform.parent;
            Vector3 newPatternPoint = new Vector3(0, 0, currentPlaneRef.GetComponent<MeshRenderer>().bounds.size.z + currentPlaneRef.position.z);
            GameObject newGeneratePattern = Instantiate(patterns[nextPatternIndex], newPatternPoint, Quaternion.identity) as GameObject;
            newGeneratePattern.transform.parent = stage;
            newGeneratePattern.name = patterns[nextPatternIndex].gameObject.name;
            if (!currentPattern.Equals(stage.GetChild(0)))
            {
                Destroy(stage.GetChild(0).gameObject);
            }
        }
    }*/
}
