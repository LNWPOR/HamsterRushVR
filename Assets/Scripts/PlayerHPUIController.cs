using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUIController : MonoBehaviour {

    public Text hpText;
    public GameObject player;

	void Update () {
        hpText.text = "HP : " + player.GetComponent<PlayerHPController>().playerCurrentHP.ToString();
    }
}
