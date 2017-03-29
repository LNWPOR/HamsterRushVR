using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuickSceneChanger : MonoBehaviour {

	void Update () {
        if (Input.GetKeyDown("z"))
        {
            SceneManager.LoadScene("PreStart");
        }else if (Input.GetKeyDown("x"))
        {
            SceneManager.LoadScene("Menu");
        }else if (Input.GetKeyDown("c"))
        {
            SceneManager.LoadScene("GamePlay");
        }
	}
}
