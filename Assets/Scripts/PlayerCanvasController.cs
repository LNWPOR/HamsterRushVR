using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCanvasController : MonoBehaviour {
    public Text playerName;

    void Awake()
    {
        playerName.text = GameManager.Instance.playerData.name;
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
