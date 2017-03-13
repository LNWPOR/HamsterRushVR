using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTypeController : MonoBehaviour {
    public GameObject CapsuleHand_R;
    public GameObject CapsuleHand_L;
    public GameObject body;
    public GameObject weapon;
    public GameObject rightPalm;
    PlayerController playerControllerScript;
    protected void AwakeType(int type)
    {
        if (GameManager.Instance.characterType.Equals(type))
        {
            this.enabled = true;
            body.SetActive(true);
            weapon.SetActive(true);

            playerControllerScript = GetComponent<PlayerController>();
            
        }
        else
        {
            this.enabled = false;
            body.SetActive(false);
            weapon.SetActive(false);
        }
    }
    protected void SetCapsuleHand()
    {
        CapsuleHand_R = playerControllerScript.CapsuleHand_R;
        CapsuleHand_L = playerControllerScript.CapsuleHand_L;
    }
    protected void SetWeaponParent()
    {
        rightPalm = playerControllerScript.HandAttachments_R.GetComponent<HandAttachmentsController>().Palm;

        weapon.transform.parent = rightPalm.transform;
        weapon.transform.position = rightPalm.transform.position;
    }
}
