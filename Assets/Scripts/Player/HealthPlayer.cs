using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] public int Health = 100;
    
    private void Awake()
    {
        int health = FindObjectsOfType<HealthPlayer>().Length;
        if (health > 1)
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
        Debug.Log(Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Debug.Log("!");
            Destroy(gameObject);
        }
    }
}
