using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingController : BaseTypeController {
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
