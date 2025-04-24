using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyProjecctile : MonoBehaviour
{
    private float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

}