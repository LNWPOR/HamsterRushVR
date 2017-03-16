﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject CapsuleHand_R;
    public GameObject CapsuleHand_L;
    public GameObject HandAttachments_R;
    public GameObject HandAttachments_L;
    private HandModelsController handModelsController;
    public bool isVRmode = false;
    void Awake()
    {
        ChangeTrinusParent();
        handModelsController = GameObject.Find("HandModels").GetComponent<HandModelsController>();
        SetMainCapsuleHands();
        SetMainHandAttachments();
    }
    void ChangeTrinusParent()
    {
        if (isVRmode)
        {
            if (GameManager.Instance.trinusLeapSetupIsSet)
            {
                GameManager.Instance.trinusLeapSetupIsSet.transform.parent = gameObject.transform;
                GameManager.Instance.trinusLeapSetupIsSet.transform.position = transform.position;
            }
        }
    }
    void SetMainCapsuleHands()
    {
        CapsuleHand_R = handModelsController.capR;
        CapsuleHand_L = handModelsController.capL;
    }
    void SetMainHandAttachments()
    {
        HandAttachments_R = handModelsController.HandR;
        HandAttachments_L = handModelsController.HandL;
    }
}