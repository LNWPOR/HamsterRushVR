using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManController : BaseTypeController {

    private int type = 2;
    void Awake()
    {
        AwakeType(type);
    }
    void Start()
    {
        SetCapsuleHand();
        SetWeaponParent();
    }
}
