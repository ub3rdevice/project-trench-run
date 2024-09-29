using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] float lvlLoadDelay = 3f;

    // void OnTriggerEnter(Collider other) { // in case we want to trigger something particular after we collide with object

    //     StartCrashSequence();

    // }

    void OnCollisionEnter(Collision other) {

        StartCrashSequence();
        
    }

    void ReloadLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartCrashSequence() 
    {
        explosionParticles.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("ReloadLevel",lvlLoadDelay);
    }
}
