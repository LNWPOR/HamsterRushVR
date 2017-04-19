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
    private GameObject instantiateSeedBullet;
    private Animator seedBulletAnimator;
    public Transform shootingDirRef;
    private Vector3 shootingVector;
    private float currentCharge = 0;
    public float speedChargeUp;
    public float sizeChargeUp;
    public float maxSpeedCharge;
    public float shootPower;
    private PlayerSeedController playerSeedControllerScript;
    private Rigidbody playerRigidbody;
    public int shootCost = 1;
    private AudioSource shooterAS;
    private void Awake()
    {
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        handExtendScirpt = capsuleHand.GetComponent<HandExtend>();
        handHoldScirpt = capsuleHand.GetComponent<HandHold>();
        shooterAS = GetComponent<AudioSource>();
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
                if (currentCharge <= maxSpeedCharge)
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
                instantiateSeedBullet.GetComponent<SphereCollider>().enabled = true;
                Destroy(instantiateSeedBullet, instantiateSeedBullet.GetComponent<SeedBulletController>().destroyDuration);
                currentCharge = 0;
                shooterAS.Play();
            }
        }


    }
}
