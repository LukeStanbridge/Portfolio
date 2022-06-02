using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject alternatBulletPrefab;
    CharController2D controller;

    private void Start()
    {
        controller = GetComponent<CharController2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {        
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            AlternateShoot();
        }
    }
    private void Shoot()
    {
        float angle = controller.facingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    private void AlternateShoot()
    {
        float angle = controller.facingRight ? 0f : 180f;
        Instantiate(alternatBulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
