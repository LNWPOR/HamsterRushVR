using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPoseController : MonoBehaviour {
    public GameObject handExtend;
    public GameObject handHold;
    public GameObject capsuleHand;
    private HandExtend handExtendScript;
    private HandHold handHoldScript;
    private void Awake()
    {
        handExtendScript = capsuleHand.GetComponent<HandExtend>();
        handHoldScript = capsuleHand.GetComponent<HandHold>();
    }
    private void Update()
    {
        if (handHoldScript.handIsHold.Equals(true))
        {
            handHold.SetActive(true);
            handExtend.SetActive(false);
        }
        else
        {
            handExtend.SetActive(true);
            handHold.SetActive(false);
        }
    }
}
