using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamFollow : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       transform.localRotation = Quaternion.Euler(0, 0, 0); 
    }
}
