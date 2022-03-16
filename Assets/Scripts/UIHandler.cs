﻿using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private TMP_Text _scoreText;
    private TMP_Text _lifeText;

    private void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        _lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
    }

    public void SetScoreText(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
    
    public void SetLifeText(int life)
    {
        _lifeText.text = $"Life: {life}";
    }
}