using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordController : WeaponController {
    public SwordManController swordManControllerScript;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            if (swordManControllerScript.currentStatmina - swordManControllerScript.cost >= 0)
            {
                Destroy(other.gameObject);
                swordManControllerScript.currentStatmina -= swordManControllerScript.cost;
            }
        }
    }

}
