using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUIController : MonoBehaviour {

    public Text hpText;
    public Text playerNameText;
    private GameObject player;
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerNameText.text = GameManager.Instance.playerData.name;
    }
	void Update () {
        hpText.text = "x " + player.GetComponent<PlayerHPController>().playerCurrentHP.ToString();
    }
}
