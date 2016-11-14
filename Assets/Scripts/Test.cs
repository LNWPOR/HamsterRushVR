using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public GameObject CapsuleHand_L;
    private Swipes CapsuleHandSwipes_L;
    public GameObject CapsuleHand_R;
    private Swipes CapsuleHandSwipes_R;

    private float movingTime = 0.2f;
    private bool canMoveRight = true;
    private bool canMoveLeft = true;
    private bool canJump = true;
    private bool canSlide = true;


    void Awake()
    {
        CapsuleHandSwipes_L = CapsuleHand_L.GetComponent<Swipes>();
        CapsuleHandSwipes_R = CapsuleHand_R.GetComponent<Swipes>();
    }
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (CapsuleHandSwipes_L.IsSwipingRight && CapsuleHandSwipes_R.IsSwipingRight && canMoveRight)
        {
            Debug.Log("Movie Left");
            StartCoroutine(WaitMoving(movingTime));
            StopMove();
        }
        else if (CapsuleHandSwipes_L.IsSwipingLeft && CapsuleHandSwipes_R.IsSwipingLeft && canMoveLeft)
        {
            Debug.Log("Movie Right");
            StartCoroutine(WaitMoving(movingTime));
            StopMove();
        }
        else if (CapsuleHandSwipes_L.IsSwipingUp && CapsuleHandSwipes_R.IsSwipingUp && canJump)
        {
            Debug.Log("Slide");
            StartCoroutine(WaitMoving(movingTime));
            StopMove();
        }
        else if (CapsuleHandSwipes_L.IsSwipingDown && CapsuleHandSwipes_R.IsSwipingDown && canSlide)
        {
            Debug.Log("Jump");
            StartCoroutine(WaitMoving(movingTime));
            StopMove();
        }
        


    }

    private IEnumerator WaitMoving(float time)
    {
        float count = 0;
        while (count < time)
        {
            count += Time.deltaTime;
            // Debug.Log(Mathf.Floor(count));
            yield return new WaitForEndOfFrame();
        }
        CanMove();
    }

    private void StopMove()
    {
        canMoveRight = false;
        canMoveLeft = false;
        canJump = false;
        canSlide = false;
    }

    private void CanMove()
    {
        canMoveRight = true;
        canMoveLeft = true;
        canJump = true;
        canSlide = true;
    }
}
