using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsShooterController : MonoBehaviour {
    public bool isRightHand;
    private PlayerController playerControllerScript;
    private GameObject HandAttachments;
    private GameObject CapsuleHand;
    private HandExtend handExtendScirpt;
    private HandHold handHoldScirpt;
    public GameObject player;
    private int stateAction = 0;
    public GameObject seedBulletPrefab;
    public Transform spawnPos;
    private GameObject instantiateSeedBullet;
    private Animator seedBulletAnimator;
    private Vector3 handFacing;
    private HandAttachmentsController handAttCtrlScript;
    public Transform shootingDirRef;
    private Vector3 shootingVector;
    private float currentCharge = 0;
    public float chargeUp = 100f;
    public float shootPower = 1500f;
    private void Awake()
    {
        playerControllerScript = player.GetComponent<PlayerController>();
    }
    void Start()
    {
        if (isRightHand)
        {
            HandAttachments = playerControllerScript.HandAttachments_R;
            CapsuleHand = playerControllerScript.CapsuleHand_R;
        }
        else
        {
            HandAttachments = playerControllerScript.HandAttachments_L;
            CapsuleHand = playerControllerScript.CapsuleHand_L;
        }
        handAttCtrlScript = HandAttachments.GetComponent<HandAttachmentsController>();
        handAttCtrlScript.SeedsShooter = gameObject;
        handExtendScirpt = CapsuleHand.GetComponent<HandExtend>();
        handHoldScirpt = CapsuleHand.GetComponent<HandHold>();
    }
    private void Update()
    {
        shootingVector = shootingDirRef.position - spawnPos.position;
        if (handHoldScirpt.handIsHold)
        {
            if (stateAction.Equals(0))
            {
                //Debug.Log("Charge");
                stateAction = 1;
                instantiateSeedBullet = Instantiate(seedBulletPrefab, transform.position, Quaternion.identity) as GameObject;
                instantiateSeedBullet.transform.parent = transform;
                instantiateSeedBullet.transform.position = spawnPos.position;
                seedBulletAnimator = instantiateSeedBullet.GetComponent<Animator>();
                seedBulletAnimator.SetInteger("State", stateAction);
            }

            if (stateAction.Equals(1))
            {
                currentCharge += chargeUp;
            }
        }

        if (handExtendScirpt.handIsExtend)
        {
            if (stateAction.Equals(1))
            {
                //Debug.Log("Throw");
                stateAction = 0;
                instantiateSeedBullet.transform.parent = null;
                instantiateSeedBullet.AddComponent<Rigidbody>();
                instantiateSeedBullet.GetComponent<Rigidbody>().AddForce(shootingVector * (shootPower + chargeUp));
                currentCharge = 0;
            }
        }

      
    }
}
