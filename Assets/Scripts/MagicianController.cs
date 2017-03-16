using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianController : BaseTypeController {
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
