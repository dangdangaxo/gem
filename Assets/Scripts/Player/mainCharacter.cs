using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mainCharacter : MonoBehaviour
{
    public static mainCharacter Instance;
    Vector2 moveInput;
    Rigidbody2D playerRigidbody;
    Animator playerAnimation;
    Transform playerPosition;
    GameObject sword;
    PlayerAttack playerAttack;
    [SerializeField] float playerSpeed = 5f;
    HealthPlayer healthPlayer;
    bool isRunning = true;


    private void Awake()
    {
        Instance = this;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        playerPosition = GetComponent<Transform>();
        sword = GameObject.Find("Sword");
        playerAttack = sword.GetComponent<PlayerAttack>();
        healthPlayer = FindObjectOfType<HealthPlayer>();
    }
    void Start()
    {
    }

    void Update()
    {
        Idling();
        if (isRunning == true)
        {
            Running();
        }
        else
        {
            Invoke("unclockMoveMent", 0.5f);
        }
        
    }
    void FixedUpdate()
    {

    }

    
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }

    //dung yen
    void Idling()
    {
        
        if(Mathf.Abs(moveInput.x + moveInput.y) > Mathf.Epsilon)
        {
            playerAnimation.SetFloat("Horizontal", moveInput.x);
            playerAnimation.SetFloat("Vertical",moveInput.y);   
        }


    }

    //Chuyen dong cua player
    void Running()
    {
        
        playerRigidbody.velocity = new Vector2(moveInput.x, moveInput.y).normalized;
        playerRigidbody.velocity *= playerSpeed;

        bool playerHorizontalSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        bool playerVerticalSpeed = Mathf.Abs(playerRigidbody.velocity.y) > Mathf.Epsilon;
        
        if(playerHorizontalSpeed)
        {
            playerAnimation.SetBool("isRunning",playerHorizontalSpeed);
        }
        else if (playerVerticalSpeed)
        {
            playerAnimation.SetBool("isRunning",playerVerticalSpeed);
        }
        else
        {
            playerAnimation.SetBool("isRunning",playerHorizontalSpeed);
            playerAnimation.SetBool("isRunning",playerVerticalSpeed);
        }
       

    }

    

    void OnFire(InputValue value)
    {   
        Debug.Log(value.isPressed);
        if (value.isPressed == true)
        {   
            lockMoveMent();
            playerAttack.isAttack = value.isPressed;
        }
    }

    void lockMoveMent()
    {
        isRunning = false;
        playerRigidbody.velocity = new Vector2(0,0);
    }

    void unclockMoveMent()
    {
        isRunning = true;
    }
    //
    /*void lockAttack()
    {
        attacking = false;
    }
    void unlockAttack()
    {
        attacking = true;
    }*/

    public void IncreaseHealth(int value)
    {
        healthPlayer.Health += value;
    }

    /*public void InteractableState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
    }

    public void SetInteractable(NPCInteraction interactable)
    {
        currentInteractable = interactable;
    }

    public void ClearInteractable()
    {
        currentInteractable = null;
    }*/
}
