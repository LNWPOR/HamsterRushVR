using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedController : MonoBehaviour {

    public int startSeed = 25;
    public int playerCurrentMaxSeed = 0;
    public int playerCurrentSeed = 0;
    PlayerMoveController playerMoveControllerScript;
    private void Awake()
    {
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
        if (playerCurrentSeed - point < 0)
        {
            playerCurrentSeed = 0;
        }
        else
        {
            playerCurrentSeed -= point;
            StartCoroutine(playerMoveControllerScript.KnockBack());
        }
    }

}
