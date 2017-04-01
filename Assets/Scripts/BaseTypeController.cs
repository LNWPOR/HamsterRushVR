using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTypeController : MonoBehaviour {
    public int type;
    public GameObject capsuleHand;
    public GameObject body;
    public GameObject weapon;
    protected WeaponController weaponControllerScript;
    public GameObject rightPalm;
    public GameObject weaponBar;
    protected void AwakeType(int type)
    {
        if (GameManager.Instance.characterType.Equals(type))
        {
            this.enabled = true;
            body.SetActive(true);
            weapon.SetActive(true);
            weaponBar.SetActive(true);
        }
        else
        {
            this.enabled = false;
            body.SetActive(false);
            weapon.SetActive(false);
        }
    }
    protected void AwakeWeapon()
    {
        weaponControllerScript = weapon.GetComponent<WeaponController>();
        SetWeaponParent();
        //capsuleHand.transform.localScale = new Vector3(0, 0, 0);
        weapon.SetActive(true);
    }
    protected void SetWeaponParent()
    {
        weapon.transform.parent = rightPalm.transform;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localEulerAngles = Vector3.zero;
        weapon.transform.localPosition = weaponControllerScript.holdingPos.localPosition;
        weapon.transform.localEulerAngles = weaponControllerScript.holdingPos.localEulerAngles;
        
    }
}
