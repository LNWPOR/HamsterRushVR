using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttachmentsController : MonoBehaviour {
    public GameObject Palm;
    public GameObject Arm;
    public GameObject Thumb;
    public GameObject PinchPoint;
    public GameObject Index;
    public GameObject Middle;
    public GameObject Ring;
    public GameObject Pinky;
    public GameObject GrabPoint;

    public Transform facingRef;
    public Vector3 handFacingVector;
    public bool handIsFaceUp = false;
    public bool handIsFaceDown = false;
    private void Awake()
    {
        handFacingVector = facingRef.position - Palm.transform.position;
    }
    private void Update()
    {
        handFacingVector = facingRef.position - Palm.transform.position;
        //Debug.DrawLine(Palm.transform.position,facingRef.position,Color.green);
        //Debug.Log("facup : " + handIsFaceUp);
        //Debug.Log("faceDown : " + handIsFaceDown);
        if (handFacingVector.y > 0.4f)
        {
            handIsFaceUp = true;
        }
        else
        {
            handIsFaceUp = false;
        }

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
