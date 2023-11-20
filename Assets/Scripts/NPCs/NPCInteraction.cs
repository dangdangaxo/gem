using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteraction : MonoBehaviour
{
    public GameObject diaglog;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("NPC is interactable");
            PlayerInput playerInput = other.GetComponent<PlayerInput>();
            if (playerInput != null)
            {
                //playerInput.SetInteractable(this);
            }
            Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("NPC is no longer interactable");
        }
        diaglog.SetActive(false);
    }

    public void Interact()
    {
        //implement logic
        //show dialog
        diaglog.SetActive(true);
    }
}
