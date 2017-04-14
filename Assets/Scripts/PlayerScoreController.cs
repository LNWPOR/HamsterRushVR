using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour {
    public int playerCurrentScore = 0;
    private float playerCurrentMaxPosZ;
    void Awake () {
        playerCurrentMaxPosZ = transform.position.z;
	}
	void Update () {
        if (transform.position.z > playerCurrentMaxPosZ)
        {
            playerCurrentScore += 1;
        }
        playerCurrentMaxPosZ = Mathf.Max(playerCurrentMaxPosZ, transform.position.z);
    }
}
