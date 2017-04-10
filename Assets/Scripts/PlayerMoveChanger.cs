using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveChanger : MonoBehaviour {
    public bool canJump;
    public bool canSlide;
    public bool canMoveUD;
    public bool haveGravity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<Rigidbody>().useGravity = haveGravity;
            PlayerMoveController playerMoveControllerScript = player.GetComponent<PlayerMoveController>();
            playerMoveControllerScript.MoveSetChange(canJump,canSlide,canMoveUD);
        }
    }
}
