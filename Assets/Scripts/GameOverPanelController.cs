using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour {

    private GameObject player;
    public Text scoresText;
    public Text seedsText;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start () {
        scoresText.text = player.GetComponent<PlayerScoreController>().playerCurrentScore.ToString();
        seedsText.text = player.GetComponent<PlayerSeedController>().playerCurrentSeed.ToString();
    }

    void Update () {
		
	}
}
