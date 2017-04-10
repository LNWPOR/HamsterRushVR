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
                Destroy(other.gameObject);
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
