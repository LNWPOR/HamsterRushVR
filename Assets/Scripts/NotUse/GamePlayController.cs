using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour {

    public GameObject player;
    private PlayerSeedController playerSeedControllerScript;
    private PlayerMoveController playerMoveControllerScript;
    public GameObject gameOverCanvas;

    private bool gameIsOver = false;
    public float tempDieAnimTime = 3f; //Note change this to equal the player dieAnim time later
    void Start()
    {
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        playerMoveControllerScript = player.GetComponent<PlayerMoveController>();
    }

    void Update()
    {
        if (playerSeedControllerScript.playerCurrentSeed.Equals(0) && !gameIsOver)
        {
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
