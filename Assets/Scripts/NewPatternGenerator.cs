using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPatternGenerator : MonoBehaviour {

    public GameObject[] patterns;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            int nextPatternIndex = (int)Mathf.Round(Random.Range(0, patterns.Length));
            Transform stage = transform.parent.parent;
            Transform currentPattern = transform.parent;
            Transform currentPlane = currentPattern.GetChild(0);
            Vector3 newPatternPoint = new Vector3(0, 0, currentPlane.GetComponent<MeshRenderer>().bounds.size.z + currentPlane.position.z);
            GameObject newGeneratePattern = Instantiate(patterns[nextPatternIndex], newPatternPoint, Quaternion.identity) as GameObject;
            newGeneratePattern.transform.parent = stage;
            newGeneratePattern.name = patterns[nextPatternIndex].gameObject.name;
            if (!currentPattern.Equals(stage.GetChild(0)))
            {
                Destroy(stage.GetChild(0).gameObject);
            }
        }
    }
}
