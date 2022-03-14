using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    
    private int _score;

    private void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void AddScore()
    {
        _score++;
        _scoreText.SetText("Score: " + _score);
    }
}
