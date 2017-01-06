using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour {

    public float ultiPoint = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerUltimateController playerUltimateContrllerScript = other.gameObject.GetComponent<PlayerUltimateController>();
            playerUltimateContrllerScript.IncreseUltiPoint(ultiPoint);
            Destroy(gameObject);
        }
    }
}
