using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSet1Trigger : MonoBehaviour {

    public float showDuration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GuideCanvasController guideCanvasControllerScript = GameObject.Find("GuideCanvas").GetComponent<GuideCanvasController>();
            if (!guideCanvasControllerScript.set1Isshow)
            {
                StartCoroutine(ShowGuide(guideCanvasControllerScript.movePanel));
                StartCoroutine(ShowGuide(guideCanvasControllerScript.seedShooterGuidePanel));
                StartCoroutine(ShowGuide(guideCanvasControllerScript.weaponGuidePanel[GameManager.Instance.characterType]));
                guideCanvasControllerScript.set1Isshow = true;
            }
        }
    }
    private IEnumerator ShowGuide(GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(showDuration);
        panel.SetActive(false);
    }
}
