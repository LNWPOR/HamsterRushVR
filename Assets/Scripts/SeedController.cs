using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour {

    public float seedPoint = 1;
    public float spinSpeed = 100f;
    void Start()
    {
        // transform.rotation = Quaternion.identity;
        //transform.parent = transform.parent.parent;
    }
    void Update()
    {
        //transform.Rotate(new Vector3(0, Time.deltaTime * spinSpeed,0), Space.Self);
        transform.RotateAround(transform.position, Vector3.up, spinSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerUltimateController playerUltimateContrllerScript = other.gameObject.GetComponent<PlayerUltimateController>();
            playerUltimateContrllerScript.IncreseUltiPoint(seedPoint);
            Destroy(gameObject);
        }
    }
}
