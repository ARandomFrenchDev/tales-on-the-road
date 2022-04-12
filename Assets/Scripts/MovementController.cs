using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] float turningSpeed = 5f;
    float limit = 120f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        TurningShip();

    }
    void TurningShip()
    {
        float xAxis = Input.GetAxis("Horizontal");

        float turning = -(turningSpeed * Time.deltaTime * xAxis);
        float finalTurn = Mathf.Clamp(turning, -limit, limit);
        transform.Translate(Vector3.left * finalTurn);

        // if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -limit)
        // {
        //     transform.Translate(Vector3.left * turningSpeed * Time.deltaTime);
        //     // while(transform.rotation.z > -5) {
        //     //     float startSpeed = Mathf.MoveTowards(0, 5, 100);
        //     //     transform.Rotate(0, 0, startSpeed);
        //     // }
        // }
        // if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        //     transform.Rotate(0, 0, Mathf.Clamp(transform.rotation.z, -5, -5));
        // }
        // if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < limit)
        // {
        //     transform.Translate(Vector3.right * turningSpeed * Time.deltaTime);
        //     // transform.Rotate(0, 0, -10);
        // }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle") {
            Debug.Log("end of run");
        }
    }
}
