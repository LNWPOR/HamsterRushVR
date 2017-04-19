using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelHitCollider : MonoBehaviour {

    private int damage = 10;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (GetComponent<MeshRenderer>().enabled)
            {
                GameObject player = collision.gameObject;
                PlayerSeedController playerSeedControllerScript = player.GetComponent<PlayerSeedController>();
                playerSeedControllerScript.DecreaseSeed(damage);
                Destroy(transform.gameObject);
            }
        }
    }
}
