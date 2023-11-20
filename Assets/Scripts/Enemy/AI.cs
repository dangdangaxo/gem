using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    LayerMask playerLayerMask;
    GameObject player, attackRange;
    Status enemyData;
    HealthPlayer playerHealth;
    Rigidbody2D enemyRigidbody;
    [SerializeField] float enemyDetectRange = 5f;
    [SerializeField] float enemyEngageRange = 0.5f;
    private float timer;
    private float coolDown = 4f;
    private void Awake()
    {
        playerLayerMask =  LayerMask.GetMask("Player");
        player = GameObject.Find("Player");
        enemyData = gameObject.GetComponent<Status>();
        attackRange = GameObject.Find("AttackRange");
        playerHealth = FindObjectOfType<HealthPlayer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {   
        
    }

    void Update()
    {
        StartCoroutine(detectPlayer());
    }

    IEnumerator detectPlayer()
    {
        bool isRunning = false;
        Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position,
         enemyDetectRange, playerLayerMask);
        if(playerCollider != null)
        {
            Debug.Log(playerCollider);
            yield return new WaitForSeconds(2f);
            float speed = enemyData.speed * Time.deltaTime; 
            /*Vector2 desiredVelocity = player.transform.position - gameObject.transform.position;
            Debug.Log(desiredVelocity);*/
            if (Vector2.Distance(transform.position, player.transform.position) > 1f)
            {
                isRunning = true;
                /*enemyRigidbody.velocity = Vector2.MoveTowards(transform.position
                ,player.transform.position, speed);*/

                /*gameObject.transform.position = Vector3.MoveTowards(transform.position
                ,player.transform.position, speed);*/

                /*Vector2 directionalToPlayer = player.transform.position - transform.position;
                directionalToPlayer.Normalize();
                Vector2 steeringForce = directionalToPlayer * speed;
                enemyRigidbody.AddForce(steeringForce);*/

                Vector2 directionalToPlayer = player.transform.position - transform.position;
                directionalToPlayer.Normalize();
                enemyRigidbody.velocity = directionalToPlayer;
                timer = 0;
                enemyData.Running(isRunning);
            }
            else
            {
                isRunning = false;
                enemyData.Running(isRunning);
                StartCoroutine(Engage());
            }    
        }
        else
        {
            yield return new WaitForSeconds(2f);
            isRunning = false;
            enemyData.Running(isRunning);
            
        }
    }
    
    IEnumerator Engage()
    {

        Collider2D playerCollider = Physics2D.OverlapCircle(gameObject.transform.position,
         enemyEngageRange, playerLayerMask);
        Debug.Log(playerCollider);
        if(playerCollider == null)
        {
            
            yield return new WaitForSeconds(1f);
            Attack();
        }
        
    }

    void Attack()
    {
        timer += Time.deltaTime;
        if (timer > coolDown)
        {   
            enemyData.Attack();
            int damage = enemyData.damage;
            playerHealth.Health -= damage;
            Debug.Log(playerHealth.Health);
            timer = 0;
            
        }

    }

    
    void OnDrawGizmos()
    {

        Vector2 i = new Vector2(0, 0);
        Gizmos.DrawWireSphere(i, enemyEngageRange);
    }
}
