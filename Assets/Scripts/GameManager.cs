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
        playerData = new PlayerData("58d55d6ff99f8c35e442d644", "LNWPOR", 0, 0);
        characterType = 1;
        DontDestroyOnLoad(gameObject);
    }
}
