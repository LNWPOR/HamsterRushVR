using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuickSceneChanger : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("PreStart");
        }else if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("Menu");
        }else if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("GamePlay");
        }
	}
}
