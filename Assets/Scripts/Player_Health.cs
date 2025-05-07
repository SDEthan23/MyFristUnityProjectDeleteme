using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthGetter healthGetter;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthGetter.ChangeHealth(currentHealth.ToString());
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthGetter.ChangeHealth(currentHealth.ToString());
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Idek");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
