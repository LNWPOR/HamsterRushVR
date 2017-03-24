using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSeedController : MonoBehaviour {

    public int startSeed = 25;
    public int playerCurrentMaxSeed = 0;
    public int playerCurrentSeed = 0;

    private PlayerController playerControllerScript;
    private PlayerMoveController playerMoveControllerScript;
    public GameObject gameOverCanvas;
    public GameObject gamePlayCanvas;
    public float tempDieAnimTime = 3f; //Note change this to equal the player dieAnim time later

    private void Awake()
    {
        playerControllerScript = GetComponent<PlayerController>();
        playerMoveControllerScript = GetComponent<PlayerMoveController>();
        playerCurrentSeed = startSeed;
        playerCurrentMaxSeed = startSeed;
    }
    public void IncreseSeed(int point)
    {
        playerCurrentSeed += point;
        if (playerCurrentSeed > playerCurrentMaxSeed)
        {
            playerCurrentMaxSeed = playerCurrentSeed;
        }

    }
    public void DecreaseSeed(int point)
    {
        if (playerCurrentSeed - point <= 0)
        {
            playerCurrentSeed = 0;
            GameOver();
        }
        else
        {
            playerCurrentSeed -= point;
            StartCoroutine(playerMoveControllerScript.KnockBack());
        }
    }
    public void ShootSeed(int point)
    {
        if (playerCurrentSeed - point <= 0)
        {
            playerCurrentSeed = 0;
            GameOver();
        }
        else
        {
            playerCurrentSeed -= point;
        }
    }
    private IEnumerator WaitDieAnim(float waitTime)
    {
        playerMoveControllerScript.enabled = false;
        playerControllerScript.gamePlayCanvas.SetActive(false);
        playerControllerScript.playerSeedsShooter.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        gameOverCanvas.SetActive(true);
    }
    private void GameOver()
    {
        StartCoroutine(WaitDieAnim(tempDieAnimTime));
    }
}
