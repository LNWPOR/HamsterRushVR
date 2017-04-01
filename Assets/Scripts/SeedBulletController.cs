using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBulletController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(collision.gameObject.name);
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            Destroy(other.gameObject);
        }
    }
}
