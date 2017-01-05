using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour {

    public bool isCollided = false;

	void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstruction"))
        {
            isCollided = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isCollided = false;
    }
}
