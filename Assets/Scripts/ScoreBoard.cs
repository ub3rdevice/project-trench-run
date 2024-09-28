using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    
    TMP_Text scoreTextField;

    void Start()
    {
        scoreTextField = GetComponent<TMP_Text>();
        scoreTextField.text = "Let the carnage begin!";
    }

    public void IncreaseScore(int amountToIncrase) 
    {
        score += amountToIncrase; // a = a + b equals a += b;
        scoreTextField.text = score.ToString(); // casting int to string
    }

}
