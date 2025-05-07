using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthGetter : MonoBehaviour
    
{

    public int maxHealth = 100;
    public int currentHealth;


    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }

    public void ChangeHealth(string health)
    {
       text.text = health;
    }
}
