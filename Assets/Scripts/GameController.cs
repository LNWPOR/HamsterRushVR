using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private GameObject player;
    private PlayerHPController playerHPControllerScript;

    public GameObject gameOverPanel;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHPControllerScript = player.GetComponent<PlayerHPController>();
    }

    void Update()
    {
        if (playerHPControllerScript.playerCurrentHP.Equals(0))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        gameOverPanel.SetActive(true);
    }
}
