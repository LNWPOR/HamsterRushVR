using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedUIController : MonoBehaviour {

    public Text seedText;
    private GameObject player;
    private PlayerSeedController playerSeedControllerScript;
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Start () {
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
	}
	void Update () {
        seedText.text = playerSeedControllerScript.playerCurrentSeed.ToString();	
	}
}
