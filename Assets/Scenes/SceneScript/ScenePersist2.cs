using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist2 : MonoBehaviour
{
     private void Awake()
    {
        int scenePresist = FindObjectsOfType<ScenePersist2>().Length;
        
        
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
