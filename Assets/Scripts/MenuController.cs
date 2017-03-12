using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject leapEventSystem;
    public GameObject trinusLeapSetup;
	void Awake()
    {
        if (!GameManager.Instance.trinusLeapSetupIsSet)
        {
            trinusLeapSetup.SetActive(true);
            GameManager.Instance.trinusLeapSetupIsSet = trinusLeapSetup;
            GameManager.Instance.trinusLeapSetupIsSet.name = "TrinusLeapSetupIsSet";
            GameManager.Instance.trinusLeapSetupIsSet.transform.parent = GameManager.Instance.transform;
        }
        else
        {
            GameManager.Instance.trinusLeapSetupIsSet.transform.position = new Vector3(0,0.5f,0);
            leapEventSystem.SetActive(true);
            Destroy(trinusLeapSetup);
        }
    }
}
