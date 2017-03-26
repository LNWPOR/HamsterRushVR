using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFaceUp : MonoBehaviour {
    public GameObject palm;
    public Transform facingRef;
    public Vector3 handFacingVector;
    public bool handIsFaceUp = false;

    private void Awake()
    {
        handFacingVector = facingRef.position - palm.transform.position;
    }
    private void Update()
    {
        handFacingVector = facingRef.position - palm.transform.position;
        //Debug.DrawLine(palm.transform.position,facingRef.position,Color.green);
        //Debug.Log("facup : " + handIsFaceUp);
        if (handFacingVector.y > 0.4f)
        {
            handIsFaceUp = true;
        }
        else
        {
            handIsFaceUp = false;
        }
    }
}
