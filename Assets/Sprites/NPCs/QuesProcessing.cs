using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuesProcessing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numProcessText;
    public int process = 0;
    public int done = 3;
    public GameObject doneTick;
    private void Awake()
    {
        int quest = FindObjectsOfType<QuesProcessing>().Length;
        if (quest > 1)
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
        numProcessText.text = process.ToString() + " / " + done.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        numProcessText.text = process.ToString() + " / " + done.ToString();
    }

    public void addProcess()
    {
        process++;
        if (process == done)
        {
            FindObjectOfType<GameSession>().addToScore(2000);
            doneTick.SetActive(true);
        }
    }

    public void resetQuest()
    {
        process = 0;
        done = 0;
        doneTick.SetActive(false);
        GameObject.Find("Quest").SetActive(false);
    }
}
