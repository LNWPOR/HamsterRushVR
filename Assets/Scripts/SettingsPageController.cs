using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPageController : MonoBehaviour {
    public GameObject defaultEventSystem;
    public GameObject leapEventSystem;
    void OnEnable()
    {
        leapEventSystem.SetActive(false);
        defaultEventSystem.SetActive(true);
    }
    void OnDisable()
    {
        defaultEventSystem.SetActive(false);
        leapEventSystem.SetActive(true);
    }
}
