/**
    **PlayerShoot.cs**

    This file focus on player's shooting mechanics
    
    ----

    *Created by Michael Chang on 11-28-2020*

    *Copyright (c) 2020. All rights reserved*
*/
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;
    public float impactForce = 30.0f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) )
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            // Check if the obstacle has Mesh
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            // Check if the obstacle has rigid body component
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject flareGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(flareGO, 2.0f);
        }
    }
}
