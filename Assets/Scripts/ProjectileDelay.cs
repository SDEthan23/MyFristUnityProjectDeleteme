using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDelay : MonoBehaviour
{

    public float ProjectileDuration = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }
   
    private IEnumerator DestroyCoroutine()
    {
        while (true)
        {

            yield return new WaitForSeconds(ProjectileDuration);
            Destroy();

        }



        // Update is called once per frame
        void Update()
        {

        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}