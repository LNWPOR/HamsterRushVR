using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypesController : MonoBehaviour {
    public GameObject[] body;
    public GameObject[] weapons;
	void Awake()
    {
        for (int i = 0; i < body.Length; i++)
        {
            if (GameManager.Instance.characterType.Equals(i))
            {
                body[i].SetActive(true);
                weapons[i].SetActive(true);
            }
            else
            {
                body[i].SetActive(false);
                weapons[i].SetActive(false);
            }
        }
    }
}
