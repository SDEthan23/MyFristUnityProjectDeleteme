using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour


{


    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float shootInterval = 2f;
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {

    }

    private IEnumerator ShootCoroutine()
    {
        while (true) {

            yield return new WaitForSeconds(shootInterval);
            ShootProjectile();
                
        }
       

    }

    private void ShootProjectile()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        { 
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position ,Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
    }
}