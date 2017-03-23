using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : BaseTypeController {
    void Awake()
    {
        AwakeType(type);
    }
    void Start()
    {
        SetUpHand();
        SetWeaponParent();
        CapsuleHand.transform.localScale = new Vector3(0, 0, 0);
        weapon.SetActive(true);
    }
}
