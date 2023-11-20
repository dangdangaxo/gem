using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    
    Rigidbody2D sawBody;
    float moveSpeed = 0.5f;
    HealthPlayer healthPlayer;

    void Start()
    {
        sawBody = GetComponent<Rigidbody2D>();
        healthPlayer = FindObjectOfType<HealthPlayer>();

    }

    
    void Update()
    {
        Moving();
    
    }

    void Moving()
    {
        sawBody.velocity = new Vector2(moveSpeed,0);
        
        /*if (Mathf.Abs(gameObject.transform.position.x) >= 0.5)
        {
            moveSpeed = -moveSpeed;
        }*/
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SawTrail")
        {
            moveSpeed = -moveSpeed;    
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
        {
            healthPlayer.Health -= 10;
        }
    }
}
