using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject grounds;
    [SerializeField] int difficulty = 1;
    [SerializeField] List<GameObject> groundsToSpawn;
    [SerializeField] public float roadSpeed = 500f;
    [SerializeField] public float despawnCountdown = 5f;
    [SerializeField] GameObject dialogueBox;

    private float offset = 2800f;
    public int nbObstacles = 0;
    void Start() {
        groundsToSpawn = new List<GameObject>();
        HandleDifficulty(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        float score = player.transform.position.z / 20;
        // Debug.Log(score);
    }

    void HandleDifficulty(int dif) {
        if(dif == 1) {
            nbObstacles = 5;
        } else if(dif == 2) {
            nbObstacles = 7;
        } else if(dif == 3) {
            nbObstacles = 10;
        } else {
            nbObstacles = 0;
        }
    }
    
    public void HandleRoadSpawner(float posZ) {
        if(groundsToSpawn.Count > 0) {
            groundsToSpawn.Clear();
        }
        foreach(Transform child in grounds.transform) {
            if(!child.gameObject.activeInHierarchy) {
                groundsToSpawn.Add(child.gameObject);
            }
        }
        int RoadToGet = Random.Range(0, groundsToSpawn.Count - 1);
        groundsToSpawn[RoadToGet].SetActive(true);
        groundsToSpawn[RoadToGet].transform.position = new Vector3(0, 0, posZ + offset);
        
    }

    public void SceneLoader(string sceneName) {
        Debug.Log(sceneName);
    }
}
