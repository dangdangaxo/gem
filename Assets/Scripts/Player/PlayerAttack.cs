using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    GameObject player;
    Vector2 attackOffset;
    LayerMask enemyLayerMask;
    Animator playerAnimation;


    [SerializeField] float attackRange = 1f;
    [SerializeField] int playerDamage = 100;
    public bool isAttack = false;
    void Awake()
    {
        player = GameObject.Find("Player");
        enemyLayerMask = LayerMask.GetMask("Enemy");
        playerAnimation = GetComponentInParent<Animator>();

    }
    void Start()
    {
        Vector2 attackOffset = gameObject.transform.position;
    }
    

    void Update()
    {
        if (isAttack == true)
        {
            isAttack = false;
            StartCoroutine(Attacking());
        }
        else
        {

        }
    }

    IEnumerator Attacking()
    {

        yield return new WaitForSeconds(0.1f);
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRange, enemyLayerMask);
            foreach (Collider2D enemies in hitEnemies)
            {
                GameObject enemy = enemies.gameObject;
                Status enemyStatus = enemy.GetComponent<Status>();
                enemyStatus.TakeDamage(playerDamage);
                
            }
            playerAnimation.SetTrigger("Attack");
            
            switch (playerAnimation.GetFloat("Horizontal") , playerAnimation.GetFloat("Vertical"))
                {
                
                    case (0,-1):
                    AttackDown();
                    break;

                    case (0,1):
                    AttackUp();
                    break;

                    case (-1,0):
                    AttackLeft();    
                    break;

                    case (1,0):
                    AttackRight();
                    break;
                    
                }
        
        
    }
        public void AttackDown()
    {
        transform.localPosition = new Vector3(attackOffset.x - 0.5f, attackOffset.y - 0.6f);
    }
    public void AttackUp()
    {
        transform.localPosition = new Vector3(attackOffset.x - 0.5f,attackOffset.y + 0.6f);
    }

    public void AttackRight()
    {   
        transform.localPosition = new Vector3(attackOffset.x + 0.5f, attackOffset.y);
    }

    public void AttackLeft()
    {
        transform.localPosition = new Vector3(attackOffset.x - 1.15f, attackOffset.y);
    }
    

}
