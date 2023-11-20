using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Launch_Wall : MonoBehaviour
{
    [SerializeField] GameObject Arrow;
    Rigidbody2D arrowRigidBody;    
    
    
    void Start()
    {
                arrowRigidBody = Arrow.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootArrow()
    {
        Vector2 arrowPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
        Instantiate(Arrow, arrowPosition, transform.rotation);
    }
}
