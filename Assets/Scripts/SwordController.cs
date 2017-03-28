using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordController : WeaponController {
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            Destroy(other.gameObject);
        }
    }

}
