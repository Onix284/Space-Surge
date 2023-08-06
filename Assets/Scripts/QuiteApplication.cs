using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteApplication : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quitting Application");
            Application.Quit();
        }
    }
}
