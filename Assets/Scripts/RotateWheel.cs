using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] float rotSpeed = 1f;
    [SerializeField] float rotTurn = 50f;
    [SerializeField] MovementController movControl;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 0, 0);
        if(movControl) {
            HandleTurning(movControl.xAxis);
        }
    }

    void HandleTurning(float xAxis) {
        float finalRot = -movControl.xAxis * rotTurn;
        transform.localRotation = Quaternion.Euler(0, finalRot, 0);
    }
}
