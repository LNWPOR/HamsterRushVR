﻿using System.Collections;
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
                guardianControllerScript.currentShieldHP -= guardianControllerScript.cost;
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