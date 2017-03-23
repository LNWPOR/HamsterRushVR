using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour {

    public bool handIsGun = false;
    public bool HandIsGun
    {
        get
        {
            return handIsGun;
        }
        set
        {
            handIsGun = value;
        }
    }
}
