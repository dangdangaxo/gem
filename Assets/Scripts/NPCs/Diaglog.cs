using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Diaglog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] line;
    public float textSpeed;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDiaglog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == line[index]){
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = line[index];
            }
        }
    }

    void StartDiaglog(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in line[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
