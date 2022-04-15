using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private bool playerEntered = false;
    GameObject groundParent;

    void Awake() {
        groundParent = this.gameObject.transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            if(!playerEntered) {
                float posZ = groundParent.transform.position.z;
                StartCoroutine(HandleTriggerEnter(posZ));
                playerEntered = true;
            }
        }
    }

    IEnumerator HandleTriggerEnter(float posZ) {
        gameManager.HandleRoadSpawner(posZ);
        yield return new WaitForSeconds(gameManager.despawnCountdown);
        groundParent.SetActive(false);
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            if(playerEntered) {
                playerEntered = false;
            }
        }
    }

}
