using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour {

    private AudioSource seedAS;
    public AudioClip getSeed;
    public int seedPoint = 1;
    private void Awake()
    {
        seedAS = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerSeedController playerSeedContrllerScript = other.gameObject.GetComponent<PlayerSeedController>();
            playerSeedContrllerScript.IncreseSeed(seedPoint);
            seedAS.PlayOneShot(getSeed);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, getSeed.length);
        }
    }
}
