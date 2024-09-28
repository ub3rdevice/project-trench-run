using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    
    public void IncreaseScore(int amountToIncrase) 
    {
        score += amountToIncrase; // a = a + b equals a += b;
        Debug.Log($"Your score is {score}");
    }

}
