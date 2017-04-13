using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBulletController : MonoBehaviour {
    private float destroyDuration = 3f;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(collision.gameObject.name);
        if (other.gameObject.tag.Equals("Destroyable"))
        {
            if (other.gameObject.name.Equals("SeedsCollector"))
            {
                other.gameObject.GetComponent<SeedsCollector>().DestroyEffect();
            }else
            {
                AudioSource otherAS = other.gameObject.GetComponent<AudioSource>();
                otherAS.Play();
                other.gameObject.GetComponent<Collider>().enabled = false;
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                Destroy(other.gameObject,otherAS.clip.length);
                Destroy(gameObject);
            }
        }else
        {
            StartCoroutine(DestroyBullet());
        }
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(destroyDuration);
    }
}
