using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject impactVFX;
    [SerializeField] Transform parentName; // Transform because this field relates to the empty gameObject created for nesting any new VFXs and empty gameObject has nothing but Transform component;
    [SerializeField] int hitPoints = 12;
    [SerializeField] int scorePerHit = 10;
    
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();  //search through the whole project and then referes to the very first scoreboard it finds. Better don't use this method anywhere where it will run for more than 1 time.
        
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
        GameObject VFX = Instantiate(impactVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = parentName;
        hitPoints--; // equals hitpoints = hitpoints - 1;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void DestroyEnemy()
    {
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = parentName; // assigning instantiated VFXs to new parent with name parentName
        Destroy(gameObject);
    }
}
