using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : WeaponController
{
    public GuardianController guardianControllerScript;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            if (guardianControllerScript.currentShieldHP - guardianControllerScript.cost >= 0)
            {
                Destroy(other.gameObject);
                guardianControllerScript.currentShieldHP -= guardianControllerScript.cost;
            }
        }
    }
}