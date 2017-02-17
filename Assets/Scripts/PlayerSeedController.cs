using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedController : MonoBehaviour {

    //public float ultiPointLimit = 10;
    public float playerCurrentSeed = 0;
    public void IncreseUltiPoint(float point)
    {
        playerCurrentSeed += point;
        //if (currentSeed + point <= ultiPointLimit) {
            //currentSeed += point;
        //}
    }

}
