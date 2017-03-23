using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerControllerScript;
    public Transform holdingPosVR;
    public Transform holdingPosLM;
    public Transform holdingPos;
    private void Awake()
    {
        playerControllerScript = player.GetComponent<PlayerController>();
        if (playerControllerScript.isVRmode)
        {
            holdingPos = holdingPosVR;
        }
        else
        {
            holdingPos = holdingPosLM;
        }
    }
}
