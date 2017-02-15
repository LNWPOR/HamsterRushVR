using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUIController : MonoBehaviour {

    public Text ScoreText;
    public GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update () {
        ScoreText.text = player.GetComponent<PlayerScoreController>().playerCurrentScore.ToString();
	}
}
