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
    [SerializeField] AudioClip deathSFX;

    AudioSource _audiosource;

    bool isInTransition = false;

    // void OnTriggerEnter(Collider other) { // in case we want to trigger something particular after we collide with object

    //     StartCrashSequence();

    // }
    void Start() 
    {
        _audiosource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other) {
        
        if (isInTransition) { return;}

        StartCrashSequence();
        
    }

    void ReloadLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartCrashSequence() 
    {
        isInTransition = true;
        _audiosource.Stop();
        _audiosource.PlayOneShot(deathSFX);

        explosionParticles.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("ReloadLevel",lvlLoadDelay);
    }
}
