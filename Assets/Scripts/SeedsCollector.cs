using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedsCollector : MonoBehaviour {
    private GameObject player;
    private PlayerSeedController playerSeedControllerScript;
    public GameObject seed;
    public GameObject seedsIncreaseText;
    private int seedIncrease = 5;
    public float destroyWaitTime;
    private AudioSource seedCollectorAS;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        seedsIncreaseText.GetComponent<TextMeshPro>().text = "+" + seedIncrease.ToString();
        seedCollectorAS = GetComponent<AudioSource>();
    }
    public void DestroyEffect()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        Destroy(seed);
        playerSeedControllerScript.IncreseSeed(seedIncrease);
        seedsIncreaseText.SetActive(true);
        seedCollectorAS.PlayOneShot(seedCollectorAS.clip);
        Destroy(gameObject,destroyWaitTime);
    }
 

}
