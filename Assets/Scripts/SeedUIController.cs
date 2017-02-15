using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedUIController : MonoBehaviour {

    public Text seedText;
    private GameObject player;
    private PlayerUltimateController playerUltimateControllerScript;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Start () {
        playerUltimateControllerScript = player.GetComponent<PlayerUltimateController>();
	}
	void Update () {
        seedText.text = "Seeds : " + playerUltimateControllerScript.currentUltiPoint;	
	}
}
