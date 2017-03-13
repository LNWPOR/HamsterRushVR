using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsPageController : MonoBehaviour {

    public GameObject leapEventSystem;
    public GameObject defaultEventSystem;
    void Awake()
    {
        SetUpLeapEvent();
    }
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
    void SetUpLeapEvent()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            leapEventSystem = GameObject.Find("MenuController").GetComponent<MenuController>().leapEventSystem;
        }
        else if (SceneManager.GetActiveScene().name.Equals("GamePlay"))
        {
            leapEventSystem = GameObject.Find("GameController").GetComponent<GameController>().leapEventSystem;
        }
    }
}
