using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTypeController : MonoBehaviour {
    public int type;
    public GameObject capsuleHand;
    //public GameObject body;
    public GameObject weapon;
    protected WeaponController weaponControllerScript;
    public GameObject palm;
    public GameObject weaponBar;
    protected void AwakeType(int type)
    {
        if (GameManager.Instance.characterType.Equals(type))
        {
            this.enabled = true;
            //body.SetActive(true);
            weapon.SetActive(true);
            weaponBar.SetActive(true);
        }
        else
        {
            this.enabled = false;
            //body.SetActive(false);
            weapon.SetActive(false);
        }
    }
}
