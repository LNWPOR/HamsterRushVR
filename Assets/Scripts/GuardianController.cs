using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuardianController : BaseTypeController
{
    public float shieldHPMax;
    public float currentShieldHP;
    public float cost;
    public float shieldRegenSpeed;
    public Image currentBar;
    public Image minimumBar;
    void Awake()
    {
        AwakeType(type);
        currentShieldHP = shieldHPMax;
        minimumBar.rectTransform.localScale = new Vector3(cost / shieldHPMax, 1, 1);
    }
    private void Update()
    {
        if (currentShieldHP + shieldRegenSpeed * Time.deltaTime < shieldHPMax)
        {
            currentShieldHP += shieldRegenSpeed * Time.deltaTime;
        }
        else
        {
            currentShieldHP = shieldHPMax;
        }
        currentBar.rectTransform.localScale = new Vector3(currentShieldHP / shieldHPMax, 1, 1);
    }
}
