using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : MonoBehaviour

{

    private void Awake()
    {
        int uIDisplay = FindObjectsOfType<UIDisplay>().Length;
        if (uIDisplay > 1)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
