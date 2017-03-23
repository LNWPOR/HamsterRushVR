using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManController : BaseTypeController {
    private HandGun handGunScript;
    void Awake()
    {
        AwakeType(type);
    }
    void Start()
    {
        SetUpHand();
        SetWeaponParent();
        handGunScript = CapsuleHand.GetComponent<HandGun>();
        CapsuleHand.transform.localScale = new Vector3(0, 0, 0);
        weapon.SetActive(true);
    }
    private void Update()
    {
        if (handGunScript.handIsGun)
        {
            Debug.Log("Fire");
        }
    }
}
