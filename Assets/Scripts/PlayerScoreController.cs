using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour {
    public int playerCurrentScore = 0;
	void Start () {
		
	}
	
	void Update () {
        playerCurrentScore += 1;
	}
}
