using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayCanvasController : MonoBehaviour {
    public GameObject player;
    private PlayerScoreController playerScoreControllerScript;
    private PlayerSeedController playerSeedControllerScript;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI seedText;
    public void Awake()
    {
        playerScoreControllerScript = player.GetComponent<PlayerScoreController>();
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
    }
    void Update()
    {
        scoreText.text = playerScoreControllerScript.playerCurrentScore.ToString();
        seedText.text = playerSeedControllerScript.playerCurrentSeed.ToString();
    }
}
