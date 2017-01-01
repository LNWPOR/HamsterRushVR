using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUIController : MonoBehaviour {

    public Text ScoreText;
    public GameObject player;

	void Update () {
        ScoreText.text = "Scores : " + player.GetComponent<PlayerScoreController>().playerCurrentScore.ToString();
	}
}
