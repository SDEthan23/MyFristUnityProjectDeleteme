using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool destroyOnCollision = false;
    public int damageToPlayer = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(collision);
        }
    }

    private void DealDamageToPlayer(Collider2D player)
    {
        Player_Health playerHealth = player.GetComponent<Player_Health>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damageToPlayer);
        }

        if (destroyOnCollision)
        {
            Destroy(this.gameObject);

        }
    }

    void Update()
    {
         
    }
}
