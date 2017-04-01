using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsShooterController : MonoBehaviour
{
    public GameObject capsuleHand;
    private HandExtend handExtendScirpt;
    private HandHold handHoldScirpt;
    public GameObject player;
    private int stateAction = 0;
    public GameObject seedBulletPrefab;
    public Transform holdingPos;
    private GameObject instantiateSeedBullet;
    private Animator seedBulletAnimator;
    public Transform shootingDirRef;
    private Vector3 shootingVector;
    private float currentCharge = 0;
    public float speedChargeUp;
    public float sizeChargeUp;
    public float maxCharge;
    public float shootPower;
    private PlayerSeedController playerSeedControllerScript;
    private Rigidbody playerRigidbody;
    public int shootCost = 1;
    public GameObject palm;
    private void Awake()
    {
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        playerRigidbody = player.GetComponent<Rigidbody>();
    }
    void Start()
    {
        transform.parent = palm.transform;
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = holdingPos.localPosition;
        transform.localEulerAngles = holdingPos.localEulerAngles;
        handExtendScirpt = capsuleHand.GetComponent<HandExtend>();
        handHoldScirpt = capsuleHand.GetComponent<HandHold>();
    }
    private void Update()
    {
        shootingVector = shootingDirRef.position - transform.position;
        //Debug.DrawLine(transform.position, shootingDirRef.position,Color.green);
        if (handHoldScirpt.handIsHold)
        {
            if (stateAction.Equals(0) && playerSeedControllerScript.playerCurrentSeed > 0)
            {
                //Debug.Log("Charge");
                stateAction = 1;
                instantiateSeedBullet = Instantiate(seedBulletPrefab, transform.position, Quaternion.identity) as GameObject;
                instantiateSeedBullet.transform.parent = transform;
                seedBulletAnimator = instantiateSeedBullet.GetComponent<Animator>();
                seedBulletAnimator.SetInteger("State", stateAction);
                playerSeedControllerScript.ShootSeed(shootCost);
            }

            if (stateAction.Equals(1))
            {
                if (currentCharge <= maxCharge)
                {
                    currentCharge += speedChargeUp;
                    Vector3 currentBulletScale = instantiateSeedBullet.transform.localScale;
                    float sizeCharged = sizeChargeUp * Time.deltaTime;
                    instantiateSeedBullet.transform.localScale = new Vector3(currentBulletScale.x + sizeCharged,
                                                                            currentBulletScale.y + sizeCharged,
                                                                            currentBulletScale.z + sizeCharged);
                }
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
                instantiateSeedBullet.GetComponent<Rigidbody>().velocity = shootingVector * (shootPower + currentCharge);
                currentCharge = 0;
            }
        }


    }
}
