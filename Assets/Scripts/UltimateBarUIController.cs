using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBarUIController : MonoBehaviour {

    public Text ulitimateBar;
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
        ulitimateBar.text = "Ultimate : " + playerUltimateControllerScript.currentUltiPoint;	
	}
}
