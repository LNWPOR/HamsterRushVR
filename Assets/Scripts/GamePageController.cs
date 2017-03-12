using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePageController : MonoBehaviour {

    public GameObject leapEventSystem;
    public GameObject defaultEventSystem;
    public GameObject gamePlayPanelVR;
    void Awake()
    {
        SetUpLeapEvent();
        defaultEventSystem.SetActive(false);
        leapEventSystem.SetActive(true);
        GameManager.Instance.gamePage = gameObject;
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
