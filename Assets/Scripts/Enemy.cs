using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject impactFX;
    //[SerializeField] Transform parentName; // Transform because this field relates to the empty gameObject created for nesting any new VFXs and empty gameObject has nothing but Transform component;
    GameObject spawnOnRuntimeObject;
    [SerializeField] int hitPoints = 12;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int scorePerKill;
    
    ScoreBoard scoreBoard;
    

    void Start()
    {
        AddRigidBody();
        SearchForScoreboard();
        SearchForSpawnOnRuntimeObject();
    }

    void SearchForSpawnOnRuntimeObject()
    {
        spawnOnRuntimeObject = GameObject.FindWithTag("SpawnAtRuntimeTag");
    }

    void SearchForScoreboard()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();  //search through the whole project and then referes to the very first scoreboard it finds. Better don't use this method anywhere where it will run for more than 1 time.
        
    }

    void AddRigidBody()
    {
        Rigidbody _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            DestroyEnemy();
        }
        
    }

    void ProcessHit()
    {   
        GameObject VFX = Instantiate(impactFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnOnRuntimeObject.transform;
        hitPoints--; // equals hitpoints = hitpoints - 1;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void DestroyEnemy()
    {
        scorePerKill = scorePerHit *2;
        scoreBoard.IncreaseScore(scorePerKill);
        GameObject VFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnOnRuntimeObject.transform; // assigning instantiated VFXs to new parent with name parentName
        Destroy(gameObject);
    }
}
