using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponController
{
    //public float damage;
    public Transform gunEnd;
    public Transform gunTarget;
    public float fireRate;
    private float nextFire = 0;
    public float shotDuration;
    private LineRenderer laserLine;
    private Vector3 shootingDir;
    public LayerMask shootingLayerMask;
    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        laserLine.SetPosition(0, gunEnd.position);
    }
    public void RayCastShoot(float time,ref float currentBullet,float cost)
    {
        if (time > nextFire)
        {
            currentBullet -= cost;
            nextFire = fireRate + time;
            StartCoroutine(ShotEffect());
            shootingDir = gunTarget.position - gunEnd.position;
            RaycastHit hit;
            if (Physics.Raycast(gunEnd.position, shootingDir, out hit, Mathf.Infinity, shootingLayerMask))
            {
                laserLine.SetPosition(1, hit.point);
                if (hit.collider.gameObject.tag.Equals("Destroyable"))
                {
                    if (hit.collider.gameObject.name.Equals("SeedsCollector"))
                    {
                        hit.collider.gameObject.GetComponent<SeedsCollector>().DestroyEffect();
                    }
                    else
                    {
                        AudioSource hitAS = hit.collider.gameObject.GetComponent<AudioSource>();
                        hitAS.Play();
                        hit.collider.gameObject.GetComponent<Collider>().enabled = false;
                        hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        Destroy(hit.collider.gameObject, hitAS.clip.length);
                    }
                }
            }
            else
            {
                laserLine.SetPosition(1, gunTarget.position);
            }
        }
    }
    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();
        laserLine.enabled = true;
        yield return new WaitForSeconds(shotDuration);
        laserLine.enabled = false;
    }
}
