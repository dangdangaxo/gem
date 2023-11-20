using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenPresist3 : MonoBehaviour
{
    private void Awake()
    {
        int scenePresist = FindObjectsOfType<ScenPresist3>().Length;
        
        
        if (scenePresist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
        
        
    }
    public void ResetScencePresist()
    {
        Destroy(gameObject);
    }
}
