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
    void Awake()
    {
        AwakeType(type);
        handGunScript = capsuleHand.GetComponent<HandGun>();
        currentBullet = maxBullet;
    }
    private void Start()
    {
        AwakeWeapon();
    }
    private void Update()
    {
        if (handGunScript.handIsGun)
        {
            Debug.Log("Fire");
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
