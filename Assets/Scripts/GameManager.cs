using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
    public string URL = "http://localhost:8000";
    public PlayerData playerData;
    public int characterType;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    void Awake()
    {
        playerData = new PlayerData("58e28708a8730c1ed41dd793", "LNWPOR", 0, 0);
        characterType = 0;
        DontDestroyOnLoad(gameObject);
    }
}
