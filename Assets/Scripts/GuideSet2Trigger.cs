using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideSet2Trigger : MonoBehaviour {

    public float showDuration;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GuideCanvasController guideCanvasControllerScript = GameObject.Find("GuideCanvas").GetComponent<GuideCanvasController>();
            if (!guideCanvasControllerScript.set2Isshow)
            {
                StartCoroutine(ShowGuide(guideCanvasControllerScript.move2Panel));
                guideCanvasControllerScript.set2Isshow = true;
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
