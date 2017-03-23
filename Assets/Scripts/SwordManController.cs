using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManController : BaseTypeController{
    void Awake()
    {
        AwakeType(type);
    }
    void Start()
    {
        SetUpHand();
        SetWeaponParent();

        CapsuleHand.transform.localScale = new Vector3(0, 0, 0);
        //handAttCtrlScript.SeedsShooter.SetActive(false);
        weapon.SetActive(true);
    }
    private void Update()
    {
        /*
        if (handExtendScirpt.handIsExtend)
        {
            CapsuleHand.transform.localScale = new Vector3(0, 0, 0);
            handAttCtrlScript.SeedsShooter.SetActive(false);
            weapon.SetActive(true);
        }
        else
        {
            CapsuleHand.transform.localScale = new Vector3(1, 1, 1);
            handAttCtrlScript.SeedsShooter.SetActive(true);
            weapon.SetActive(false);
        }*/
    }
}
