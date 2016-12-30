using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveData {
    public string name;
    public bool canMove = true;
    public bool isMoving = false;

    public PlayerMoveData(string newName)
    {
        name = newName;
    }
}
