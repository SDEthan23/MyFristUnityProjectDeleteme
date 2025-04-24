using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{

    int intVar = 4; //100
    string stringVar = "Ethan :)";
    float floatVar = 5.5f;
    bool boolVar = false;

    float health = 100f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(stringVar);
        stringVar = "5";
        Debug.Log(stringVar);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
