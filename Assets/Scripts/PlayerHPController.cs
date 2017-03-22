using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour {

    public int playerLimitHP = 5;
    public int playerCurrentHP;

    PlayerMoveController playerMoveControllerScript;
    void Awake()
    {
        playerMoveControllerScript = gameObject.GetComponent<PlayerMoveController>();
    }
	void Start () {
        playerCurrentHP = playerLimitHP;
    }
    public void DecresePlayerHP(int damage)
    {
        if (playerCurrentHP - damage < 0)
        {
            playerCurrentHP = 0;
        }else
        {
            playerCurrentHP -= damage;
            StartCoroutine(playerMoveControllerScript.KnockBack());
        }
    }
    public void IncresePlayerHP(int heal)
    {
        if (playerCurrentHP + heal > playerLimitHP)
        {
            playerCurrentHP = playerLimitHP;
        }else
        {
            playerCurrentHP += heal;
        }
    }
}
