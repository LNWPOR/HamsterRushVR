using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    private PlayerSeedController playerSeedControllerScript;
    private PlayerMoveController playerMoveControllerScript;
    public GameObject leapEventSystem;
    public GameObject gameOverCanvas;
    public bool isTestGamePlay;

    private bool gameIsOver = false;
    public float tempDieAnimTime = 3f; //Note change this to equal the player dieAnim time later
    void Awake()
    {
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        playerMoveControllerScript = player.GetComponent<PlayerMoveController>();
        if (!isTestGamePlay)
        {
            GameManager.Instance.gamePage.GetComponent<GamePageController>().gamePlayPanelVR.SetActive(true);
        }
        
    }

    void Update()
    {
        if (playerSeedControllerScript.playerCurrentSeed.Equals(0) && !gameIsOver)
        {
            //GameOver();
            gameIsOver = true;
            playerMoveControllerScript.enabled = false;
            StartCoroutine(WaitDieAnim(tempDieAnimTime));
        }
    }

    private IEnumerator WaitDieAnim(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            GameOver();
        }
    }
    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
