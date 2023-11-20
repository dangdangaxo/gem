using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallShooter : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    Rigidbody2D ballRigidBody;

    private void Awake()
    {
        
    }
    private void Start()
    {
        ballRigidBody = Ball.GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        //ballRigidBody.velocity = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y - 1);
    }

    public void ShootIceBall()
    {
        Vector2 ballPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1.5f);
        Instantiate(Ball, ballPosition, transform.rotation);
    }
}
