using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour {

    public bool isCollided;
    private void OnTriggerEnter(Collider other)
    {
        isCollided = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isCollided = false;
    }
}
