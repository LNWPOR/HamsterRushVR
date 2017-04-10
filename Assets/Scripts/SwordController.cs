using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordController : WeaponController {
    public SwordsManController swordManControllerScript;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            if (swordManControllerScript.currentStatmina - swordManControllerScript.cost >= 0)
            {
                swordManControllerScript.currentStatmina -= swordManControllerScript.cost;
                if (other.gameObject.name.Equals("SeedsCollector"))
                {
                    other.gameObject.GetComponent<SeedsCollector>().DestroyEffect();
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }

}
