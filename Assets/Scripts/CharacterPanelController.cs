using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelController : MonoBehaviour {

    public Button[] characterButton;
    public Sprite normalButton;
    public Sprite pressButton;
    public void OnClickCharacterButton(int type)
    {
        GameManager.Instance.characterType = type;
        ChangeButtonImage(type);
    }
    void ChangeButtonImage(int type)
    {
        for (int i = 0;i<characterButton.Length;i++)
        {
            if (i.Equals(type))
            {
                characterButton[i].GetComponent<Image>().sprite = pressButton;
            }else
            {
                characterButton[i].GetComponent<Image>().sprite = normalButton;
            }
        }
    }
}
