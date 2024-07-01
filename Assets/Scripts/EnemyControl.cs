using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int enemyHealth;
    public int moveAnimation;
    private Animator _compAnimator;
    private SpriteRenderer _compSpriteRenderer;
    public float speed;
    public GameObject objective;
    public EnemyChasingController chasingEnemyArea;
    private bool attacking;
    public GameObject attackRange;
    private void Awake()
    {
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
        _compAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (objective.transform.position.x >= transform.position.x)
        {
            _compSpriteRenderer.flipX = true;
        }
        else
        {
            _compSpriteRenderer.flipX = false;
        }
        _compAnimator.SetInteger("Moving", moveAnimation);
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (chasingEnemyArea.isChasingPlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
            moveAnimation = 1;
        }
        else
        {
            moveAnimation = 0;
        }       
    }
    private void Attack()
    {
        _compAnimator.SetTrigger("Attacking");
        Instantiate(attackRange, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = 0;
            chasingEnemyArea.isChasingPlayer = false;
            Attack();
        }              
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = 3;
            chasingEnemyArea.isChasingPlayer = true;
        }
        
    }
}
