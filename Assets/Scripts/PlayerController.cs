using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool isVRmode = false;
    public GameObject HandModels_VR;
    public GameObject HandModels_LM;
    private GameObject HandModels;
    private HandModelsController handModelsController;
    public GameObject CapsuleHand_R;
    public GameObject CapsuleHand_L;
    public GameObject HandAttachments_R;
    public GameObject HandAttachments_L;
    public GameObject trinusCamera;
    public GameObject leapMotionCamera;
    public Transform mainCameraTransform;
    void Awake()
    {
        if (isVRmode)
        {
            mainCameraTransform = trinusCamera.transform;
            HandModels = HandModels_VR;
        }else
        {
            mainCameraTransform = leapMotionCamera.transform;
            HandModels = HandModels_LM;
        }
        HandSetup();
    }
    void HandSetup()
    {
        handModelsController = HandModels.GetComponent<HandModelsController>();
        SetMainCapsuleHands();
        SetMainHandAttachments();
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
