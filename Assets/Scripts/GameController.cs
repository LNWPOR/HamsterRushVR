using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject player;
    private PlayerHPController playerHPControllerScript;

    public GameObject gameOverCanvas;

    private bool gameIsOver = false;
    public float tempDieAnimTime = 3f; //Note change this to equal the player dieAnim time later
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHPControllerScript = player.GetComponent<PlayerHPController>();
    }

    void Update()
    {
        if (playerHPControllerScript.playerCurrentHP.Equals(0) && !gameIsOver)
        {
            //GameOver();
            gameIsOver = true;
            player.GetComponent<PlayerMoveController>().enabled = false;
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
