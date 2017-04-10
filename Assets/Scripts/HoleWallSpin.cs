using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleWallSpin : MonoBehaviour {

    public bool isSpinClock;
    void Awake()
    {
        GetComponent<Animator>().SetBool("isSpinClock", isSpinClock);
    }
}
