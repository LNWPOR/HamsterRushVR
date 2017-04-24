using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunManController : BaseTypeController {
    private HandGun handGunScript;
    public float maxBullet;
    public float currentBullet;
    public float cost;
    public float bulletGainSpeed;
    public Image currentBar;
    public Image minimumBar;
    private GunController gunControllerScript;
    void Awake()
    {
        AwakeType(type);
        handGunScript = capsuleHand.GetComponent<HandGun>();
        currentBullet = maxBullet;
        gunControllerScript = weapon.GetComponent<GunController>();
        minimumBar.rectTransform.localScale = new Vector3(cost / maxBullet, 1, 1);
    }
    private void Update()
    {
        if (handGunScript.handIsGun)
        {
            if (currentBullet - cost >= 0)
            {
                gunControllerScript.RayCastShoot(Time.time, ref currentBullet, cost);
            }       
        }
        if (currentBullet + bulletGainSpeed * Time.deltaTime < maxBullet)
        {
            currentBullet += bulletGainSpeed * Time.deltaTime;
        }
        else
        {
            currentBullet = maxBullet;
        }
        currentBar.rectTransform.localScale = new Vector3(currentBullet / maxBullet, 1, 1);
    }
}
