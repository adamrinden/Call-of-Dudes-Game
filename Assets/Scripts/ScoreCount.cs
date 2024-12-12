using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    private int currentScore = 0; // Variable to keep track of the score

    void Start()
    {
        UpdateScore(); 
    }

    public void AddScore(int points)
    {
        currentScore += points; 
        UpdateScore(); 
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore; 
    }
}