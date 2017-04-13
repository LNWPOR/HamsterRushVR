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
                    AudioSource otherAS = other.gameObject.GetComponent<AudioSource>();
                    otherAS.Play();
                    other.gameObject.GetComponent<Collider>().enabled = false;
                    other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(other.gameObject, otherAS.clip.length);
                }
            }
        }
    }

}
