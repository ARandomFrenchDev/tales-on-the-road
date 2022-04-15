using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovementController : MonoBehaviour
{

    Rigidbody rb;
    
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] ParticleSystem speedParticle;
    [SerializeField] GameObject particleEmit;
    [SerializeField] TrailRenderer[] trailRenderers;
    [SerializeField] AudioClip driftSound;

    [SerializeField] float turningSpeed = 5f;
    [SerializeField] float carRotLimit = 7f;
    [SerializeField] float carPitchFactor = 17f;
    [SerializeField] List<GameObject> wheels = new List<GameObject>(2);
    float limit = 120f;
    bool turning;
    AudioSource audioSource;
    public float xAxis;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlayer();
        TurningPlayer();
    }
    void MovingPlayer() {
        xAxis = Input.GetAxis("Horizontal");

        float turnOffset = (turningSpeed * Time.deltaTime * xAxis);
        float newXPos = turnOffset + transform.position.x;
        float finalTurn = Mathf.Clamp(newXPos, -limit, limit);
        transform.position = new Vector3(finalTurn, transform.position.y, transform.position.z);
        
        // handleFov();

    }
    void handleFov() {
        float fov = Mathf.SmoothStep(cinemachineVirtualCamera.m_Lens.FieldOfView, 60f, 2f);
        // float newxAxis = xAxis > 0 ? xAxis : -xAxis;
        // Debug.Log(Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, 60f, newxAxis));
        if(xAxis > 0.2 || xAxis < -0.2) {
            cinemachineVirtualCamera.m_Lens.FieldOfView = fov; // change smoothly this value
        } else {
            cinemachineVirtualCamera.m_Lens.FieldOfView = 50f;
        }
    }
    void TurningPlayer()
    {

        float roll = transform.position.x / carRotLimit; // division de la position du joueur par le nombre de fois qu'on veut avoir comme degrés de tournés
        float rollClampfed = Mathf.Clamp(roll, -carPitchFactor, carPitchFactor);
        float t = xAxis < 0 ? -xAxis : xAxis;
        transform.localRotation = Quaternion.Euler(0, t * -rollClampfed, 0);
        
        turning = t > 0.1 ? true : false;
        if(turning) {
            // StartTrailMarks();
            StartDriftSound();

        } else {
            // StopTrailMarks();
            StopDriftSound();
        }
        HandleSpeedParticle(t);
        
    }

    void StartTrailMarks() {
        foreach(TrailRenderer T in trailRenderers) {
            T.emitting = true;
        }
        Debug.Log("skrrrrr");
        
    }

    void StopTrailMarks() {
        foreach(TrailRenderer T in trailRenderers) {
            T.emitting = false;
        }
        Debug.Log("not skrrrrr");
        
    }

    void HandleSpeedParticle(float t) {
        if(t > 0.1f) {
            if(!speedParticle.isPlaying) {
                speedParticle.Play(); 
            } 
        } else {
            if(speedParticle.isPlaying) {
                speedParticle.Stop();
            }
        }
        speedParticle.transform.position = new Vector3(
            particleEmit.transform.position.x, 
            particleEmit.transform.position.y, 
            particleEmit.transform.position.z
        );
    }

    void StartDriftSound() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(driftSound);
    }

    void StopDriftSound() {
        audioSource.Stop();
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle") {
            Debug.Log("end of run");
        }
    }
}
