using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject Player;
    public Vector3 holdingPos;
    void OnEnable()
    {
        transform.localPosition = holdingPos;
    }
}
