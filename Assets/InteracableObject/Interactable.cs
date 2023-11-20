using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public UnityEvent isTrigger;
    bool isInteract = true;
    [SerializeField] public InputAction inputValue;
    GameSession gameSession;

    private void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();        
    }
    void Start()
    {
        
    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (isInteract == false)
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            isInteract = true;    
            isTrigger.Invoke();
                
            
            Debug.Log(isInteract);
            
        } 
    }
    private void OnTriggerExit2D(Collider2D other)
    {   
        if(other.gameObject.tag == "Player")
        {
            isInteract = false;

        }
        Debug.Log(isInteract);
    }

    private void OnEnable()
    {
        inputValue.Enable();        
    }

    private void OnDisable()
    {
        inputValue.Disable();        
    }
    public void interracted()
    {
        Debug.Log("HI");
        gameSession.addToScore(1000);

    }
}
