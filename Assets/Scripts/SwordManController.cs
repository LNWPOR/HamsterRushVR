using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwordManController : BaseTypeController{

    public float staminaMax;
    public float currentStatmina;
    public float cost;
    public float staminaGainSpeed;
    public Image currentBar;
    void Awake()
    {
        AwakeType(type);
        
        currentStatmina = staminaMax;
    }
    private void Start()
    {
        AwakeWeapon();
    }
    private void Update()
    {
        if (currentStatmina + staminaGainSpeed * Time.deltaTime < staminaMax)
        {
            currentStatmina += staminaGainSpeed * Time.deltaTime;
        }
        else
        {
            currentStatmina = staminaMax;
        }
        currentBar.rectTransform.localScale = new Vector3(currentStatmina/staminaMax,1,1);


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
