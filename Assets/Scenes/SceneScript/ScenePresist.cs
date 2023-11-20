using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePresist : MonoBehaviour
{
    
    private void Awake()
    {
        int scenePresist = FindObjectsOfType<ScenePresist>().Length;
        
        
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
