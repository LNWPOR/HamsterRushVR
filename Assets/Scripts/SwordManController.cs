using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManController : BaseTypeController{
    private bool handIsHolding = false;
    public bool HandIsHolding
    {
        get
        {
            return handIsHolding;
        }
        set
        {
            handIsHolding = value;
        }
    }
    void Awake()
    {
        AwakeType(type);
    }
    void Start()
    {
        SetWeaponParent();
    }
    private void Update()
    {
        if (handIsHolding)
        {
            weapon.SetActive(true);
        }else
        {
            weapon.SetActive(false);
        }
    }
}
