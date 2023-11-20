using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Status : MonoBehaviour
{
    Animator enemyAnimation;
    Rigidbody2D enemyRigigbody;
    GameObject player;
    public Enemy status;
    public int health, damage, speed, flip;
    public bool isDeath = false;
    public UnityEvent Event;

    void Awake()
    {
        this.health = status.GetHealth();
        this.damage = status.GetDamage();
        this.speed = status.GetSpeed();
        enemyAnimation = GetComponent<Animator>();
        enemyRigigbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        player = GameObject.Find("Player");
        
    }
    void Update()
    {
        State();
        Flip();
    }

    public void TakeDamage(int damage)
    {
        
        this.health -= damage;
        KnockBack();
        enemyAnimation.SetTrigger("Hurt");
        Debug.Log(this.health);
        if(this.health <= 0)
        {
            Debug.Log("NO DEATH");
            if (FindObjectOfType<QuesProcessing>() != null)
            {
            FindObjectOfType<QuesProcessing>().addProcess();
            }
            Invoke("Death", 0.1f);
        }
    }
    
    void State()
    {
        
    }
    
    public void Running(bool isRunning)
    {
        if (!isRunning)
        {
            enemyRigigbody.velocity = new Vector2(0, 0);
        }
        enemyAnimation.SetBool("isRunning", isRunning);
        
    }

    void Death()
    {
        FindObjectOfType<GameSession>().addToScore(500);
        Destroy(gameObject);

    }
    void Flip()
    {
        bool movementValue = Mathf.Abs(enemyRigigbody.velocity.x) > Mathf.Epsilon;
        
        if (movementValue)
        {
            transform.localScale = new Vector2 (Mathf.Sign(enemyRigigbody.velocity.x), 1f);
        };
    
    }

    public void Attack()
    {
       enemyAnimation.SetTrigger("Attack"); 
       
    }

    void KnockBack()
    {
        
        Vector2 knockBackDirection = transform.position - player.transform.position;
        knockBackDirection.Normalize();
        
        enemyRigigbody.AddForce(knockBackDirection * 20f, ForceMode2D.Impulse);
        
    }

    void DropItems()
    {
        
    }
}
