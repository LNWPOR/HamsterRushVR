using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateController : MonoBehaviour {

    public float ultiPointLimit = 10;
    public float currentUltiPoint = 0;
    public void IncreseUltiPoint(float point)
    {
        if (currentUltiPoint + point <= ultiPointLimit) {
            currentUltiPoint += point;
        }
    }

}
