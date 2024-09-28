using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float lvlLoadDelay = 1f;
    void OnTriggerEnter(Collider other) {

        StartCrashSequence();

    }

    void ReloadLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartCrashSequence() 
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel",lvlLoadDelay);
    }
}
