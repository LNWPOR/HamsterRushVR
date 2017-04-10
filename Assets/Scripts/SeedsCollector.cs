using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedsCollector : MonoBehaviour {
    private GameObject player;
    private PlayerSeedController playerSeedControllerScript;
    public GameObject seed;
    public GameObject seedsIncreaseText;
    public int seedIncrease;
    public float destroyWaitTime;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
        seedsIncreaseText.GetComponent<TextMeshPro>().text = "+" + seedIncrease.ToString();
    }
    public void DestroyEffect()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        Destroy(seed);
        playerSeedControllerScript.IncreseSeed(seedIncrease);
        StartCoroutine(StartSeedsIncreaseText());
    }
    private IEnumerator StartSeedsIncreaseText()
    {
        seedsIncreaseText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
 

}
