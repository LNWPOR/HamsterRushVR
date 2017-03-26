using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFaceDown : MonoBehaviour {
    public GameObject palm;
    public Transform facingRef;
    public Vector3 handFacingVector;
    public bool handIsFaceDown = false;

    private void Awake()
    {
        handFacingVector = facingRef.position - palm.transform.position;
    }
    private void Update()
    {
        handFacingVector = facingRef.position - palm.transform.position;
        //Debug.DrawLine(palm.transform.position,facingRef.position,Color.green);
        //Debug.Log("faceDown : " + handIsFaceDown);
        if (handFacingVector.y < -0.4f)
        {
            handIsFaceDown = true;
        }
        else
        {
            handIsFaceDown = false;
        }

    }
}
