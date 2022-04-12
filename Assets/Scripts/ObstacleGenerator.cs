using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [SerializeField] GameObject crate;
    [SerializeField] GameManager gameManager;
    GameObject RandomObstacle() {
        return crate;
    }

    Vector3 RandomPosition() {
        Vector3 pos = new Vector3(Random.Range(0, 1), 1.22f, Random.Range(0, 1));
        return pos;
    }

    Quaternion RandomRotation() {
        Quaternion qua = new Quaternion();
        return qua;
    }
}
