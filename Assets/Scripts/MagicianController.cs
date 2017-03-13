using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianController : BaseTypeController {

    private int type = 1;
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
