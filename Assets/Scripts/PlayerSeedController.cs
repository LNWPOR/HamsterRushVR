using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeedController : MonoBehaviour {
    
    public float playerCurrentSeed = 0;
    
    public void IncreseUltiPoint(float point)
    {
        playerCurrentSeed += point;
    }

}
