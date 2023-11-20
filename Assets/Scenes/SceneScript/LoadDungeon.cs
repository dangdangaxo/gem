using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDungeon : MonoBehaviour
{
    int currentScene;
    GameObject mainCharacter;
    GameSession gameSession;
    ScenePresist scenePresist;
    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();    
        scenePresist = FindObjectOfType<ScenePresist>();    
    }
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        loadDungeon();
        if (gameObject.tag == "GateDungeon3" && currentScene == 2)
        {
            SceneManager.LoadScene(4);
        }
        if (gameObject.tag == "GateDungeon2" && currentScene == 2)
        {
            SceneManager.LoadScene(3);
        }
        if (gameObject.tag == "ExitGame" && currentScene == 2)
        {
            SceneManager.LoadScene(5);
        }
        
    }

    private void loadDungeon()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        switch (currentScene)
        {
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(2);
                break;
            case 4:
                SceneManager.LoadScene(2);
                break;
            
        }
        
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void tryAgain()
    {
        gameSession.resetScore();
        FindObjectOfType<ScenePresist>().ResetScencePresist();
        
        if (FindObjectOfType<ScenePersist2>() == null || FindObjectOfType<ScenPresist3>() == null)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            FindObjectOfType<ScenPresist3>().ResetScencePresist();
            FindObjectOfType<ScenePersist2>().ResetScencePresist();
        }
        
        ;
        if (FindObjectOfType<QuesProcessing>() != null)
        {
        FindObjectOfType<QuesProcessing>().resetQuest();
        }
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
