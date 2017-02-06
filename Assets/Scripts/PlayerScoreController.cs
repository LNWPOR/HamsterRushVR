using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour {
    public int playerCurrentScore = 0;
    private Vector3 playerPreviousPos;
    void Start () {
        playerPreviousPos = transform.position;
	}
	void Update () {
        
        if (!playerPreviousPos.z.Equals(transform.position.z))
        {
            playerCurrentScore += 1;
        }
        playerPreviousPos = transform.position;

    }
}
