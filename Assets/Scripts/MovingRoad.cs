using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRoad : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private float speed = 5f;
    // [SerializeField] float maxSpeed = 6f;
    // [Range(0, 1)] public float percentageSpeed = 0.5f;
    void Update()
    {
        MovingGround();
    }
    void MovingGround()
    {
        speed = gameManager.roadSpeed;
        float movingSpeed = -(speed *  Time.deltaTime);
        transform.Translate(Vector3.left * movingSpeed);
        // rb.AddForce(0, 0, startSpeed * Time.deltaTime);

        // if (transform.position.z > 10)
        // { // acceleration
        //     startSpeed = Mathf.MoveTowards(startSpeed, maxSpeed, percentageSpeed * Time.deltaTime);
        //     rb.AddForce(0, 0, startSpeed * Time.deltaTime);
        // }
    }
}
