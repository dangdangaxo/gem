using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    
    public float score;

    [SerializeField] public TextMeshProUGUI scoreText;
    private void Awake()
    {
        int score = FindObjectsOfType<GameSession>().Length;
        if (score > 1)
        {
            Destroy(gameObject);
        }
        
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = scoreText.ToString();
    }
    public void addToScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void resetScore()
    {
        score = 0;
    }

    
}
