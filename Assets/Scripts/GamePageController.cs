using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GamePageController : MonoBehaviour {
    public GameObject defaultEventSystem;
    public GameObject leapEventSystem;
    void Awake()
    {
        defaultEventSystem.SetActive(false);
        leapEventSystem.SetActive(true);
    }
}
