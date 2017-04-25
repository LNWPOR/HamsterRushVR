using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstrucleHitCollider : MonoBehaviour {

    private int damage = 1;
    public MeshRenderer meshRef;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (meshRef.enabled)
            {
                GameObject player = other.gameObject;
                PlayerSeedController playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
                playerSeedControllerScript.DecreaseSeed(damage);
            }
        }
    }
}
