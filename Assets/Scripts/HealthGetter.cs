using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthGetter : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeHealth(string Health)
    {
        text.text = Health;
    }
}