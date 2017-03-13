using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManController : BaseTypeController{
    private int type = 0;
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
