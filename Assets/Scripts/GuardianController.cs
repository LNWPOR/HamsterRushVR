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
        AwakeWeapon();
    }
}
