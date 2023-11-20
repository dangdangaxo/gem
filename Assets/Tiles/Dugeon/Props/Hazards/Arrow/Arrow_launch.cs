using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_launch : MonoBehaviour
{
    Rigidbody2D arrowRigidBody;
    Animator arrowAnimation;
    HealthPlayer healthPlayer;

    void Start()
    {
        arrowRigidBody = GetComponent<Rigidbody2D>();
        arrowAnimation = GetComponent<Animator>();
        healthPlayer = FindObjectOfType<HealthPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowRigidBody.velocity = new Vector2(0,-3);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
        {
            Debug.Log("HIT");
            arrowAnimation.SetTrigger("OnDestroy");
            healthPlayer.Health -= 10;
            Destroy(gameObject);
        }
        
    }

    public void DestroyArrow()
    {
        
    }
}
