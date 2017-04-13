using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    
    void Awake()
    {
        GameObject backgroundAudioInUse = GameObject.Find("BackgroundAudioInUse");
        if (!object.Equals(backgroundAudioInUse,null))
        {
            Destroy(gameObject);
        }else
        {
            gameObject.name = "BackgroundAudioInUse";
            DontDestroyOnLoad(gameObject);
        }
    }
}
