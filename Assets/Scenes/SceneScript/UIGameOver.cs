using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    GameSession gameSession;
    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
    }
    void Start()
    {
        Debug.Log(gameSession.score.ToString());
        scoreText.text = gameSession.score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
