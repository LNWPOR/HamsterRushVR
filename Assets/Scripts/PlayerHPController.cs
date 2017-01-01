using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour {

    public int playerLimitHP = 5;
    public int playerCurrentHP;
	
	void Start () {
        playerCurrentHP = playerLimitHP;
    }

	void Update () {
        if (playerCurrentHP.Equals(0))
        {
            Debug.Log("GameOver");
        }	
	}
    public void DecresePlayerHP(int damage)
    {
        if (playerCurrentHP - damage < 0)
        {
            playerCurrentHP = 0;
        }else
        {
            playerCurrentHP -= damage;
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
