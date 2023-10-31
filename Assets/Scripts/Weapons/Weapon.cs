using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit rayHit;

        Physics.Raycast(fpCamera.transform.position, transform.forward, out rayHit, range);

        Debug.Log("I hit this thing: " + rayHit.transform.name);
    }
}
