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
        AwakeWeapon();
        handGunScript = capsuleHand.GetComponent<HandGun>();
    }
    private void Update()
    {
        if (handGunScript.handIsGun)
        {
            Debug.Log("Fire");
        }
    }
}
