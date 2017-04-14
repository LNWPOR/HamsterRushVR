using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour {

    public bool isCollided;
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            isCollided = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            isCollided = false;
        }
    }
}
