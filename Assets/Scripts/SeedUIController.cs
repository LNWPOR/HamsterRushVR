using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedUIController : MonoBehaviour {

    public Text seedText;
    private GameObject player;
    private PlayerSeedController playerUltimateControllerScript;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Start () {
        playerUltimateControllerScript = player.GetComponent<PlayerSeedController>();
	}
	void Update () {
        seedText.text = playerUltimateControllerScript.playerCurrentSeed.ToString();	
	}
}
