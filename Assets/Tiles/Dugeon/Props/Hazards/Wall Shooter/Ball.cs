using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D ballRigidBody;
    Animator ballAnimation;
    HealthPlayer healthPlayer;

    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballAnimation = GetComponent<Animator>();
        healthPlayer = FindObjectOfType<HealthPlayer>();

    }

    void Update()
    {
        ballRigidBody.velocity = new Vector2(0,-3f);
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
        {
            healthPlayer.Health -= 10;
            ballAnimation.SetTrigger("OnDestroy");
            Invoke("destroyBall",0.1f);
        }
    }

    public void destroyBall()
    {
        Destroy(gameObject);
    }
    
}
