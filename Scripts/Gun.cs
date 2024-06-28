using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public int maxAmmo = 10;
    private int currentAmmo = 10;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public GameObject weapons;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    IEnumerator Reload()
    {
        if (!isReloading)
        {
            isReloading = true;

            //reloadAnimator.SetBool("Reloading", true);
            weapons.SetActive(false);

            yield return new WaitForSeconds(reloadTime);

            //reloadAnimator.SetBool("Reloading", false);
            weapons.SetActive(true);

            currentAmmo = maxAmmo;
    //        GameManager.instance.Ammo(currentAmmo);
            yield return new WaitForSeconds(0.2f);
            isReloading = false;

        }

    }

    void OnShoot()
    {


        if (isReloading)
        {
            return;
        }

        currentAmmo--;


        if (currentAmmo <= 0)
        {
            //StartCoroutine(Reload());
            return;
        }

        muzzleFlash.Play();

  //      GameManager.instance.Ammo(currentAmmo);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            GiftBox giftbox = hit.transform.GetComponent<GiftBox>();
            if (giftbox != null)
            {
                giftbox.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

         //   GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //    Destroy(impactGO, 2f);
        }

    }

}
