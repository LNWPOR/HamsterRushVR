using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTriggerCollider : MonoBehaviour {
    public float barrelSpeed;
    public GameObject barrel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            barrel.AddComponent<Rigidbody>();
            Rigidbody barrelRigidbody = barrel.GetComponent<Rigidbody>();
            barrelRigidbody.constraints =   RigidbodyConstraints.FreezePositionX|
                                            RigidbodyConstraints.FreezeRotationZ;
            barrelRigidbody.AddForce(new Vector3( 0,0, -barrelSpeed));
        }
    }
}
