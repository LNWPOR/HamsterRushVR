using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCanvasController : MonoBehaviour {
    public TextMeshProUGUI playerName;

    void Awake()
    {
        playerName.text = GameManager.Instance.playerData.name;
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("GamePlay");
    }

}
