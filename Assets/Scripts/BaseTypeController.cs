using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTypeController : MonoBehaviour {
    public int type;
    protected GameObject HandAttachments;
    protected GameObject CapsuleHand;
    public GameObject body;
    public GameObject weapon;
    public GameObject rightPalm;
    protected PlayerController playerControllerScript;
    protected HandAttachmentsController handAttCtrlScript;
    protected HandExtend handExtendScirpt;
    protected HandHold handHoldScirpt;
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
    protected void SetUpHand()
    {
        HandAttachments = playerControllerScript.HandAttachments_R;
        handAttCtrlScript = HandAttachments.GetComponent<HandAttachmentsController>();
        CapsuleHand = playerControllerScript.CapsuleHand_R;
        rightPalm = handAttCtrlScript.Palm;
        handExtendScirpt = CapsuleHand.GetComponent<HandExtend>();
        handHoldScirpt = CapsuleHand.GetComponent<HandHold>();
    }
    protected void SetWeaponParent()
    {
        weapon.transform.parent = rightPalm.transform;
        weapon.transform.position = rightPalm.transform.position;
    }
}
