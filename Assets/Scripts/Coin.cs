using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool coinDestroy = true;
    public int playerScore = 1;
    public int coinValue = 1;

    [SerializeField] private AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            if (coinDestroy)
            {
                Destroy(gameObject);
                playerScore += coinValue;
                Debug.Log(playerScore);
            }
        }
    }
}