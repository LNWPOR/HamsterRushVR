using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHold : MonoBehaviour {

    public bool handIsHold = false;
    public bool HandIsHold
    {
        get
        {
            return handIsHold;
        }
        set
        {
            handIsHold = value;
        }
    }
}
