using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int playerHealth = 8;
    public Transform shootingPoint;
    private Animator _compAnimator;
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    private EnemyControl enemy;
    public GameObject bulletPrefab;
    public BulletMovement bullet;
    public AudioSource _audioSource;
    public float speedX=5;
    public float speedY=3;
    public float xDirection;
    public float yDirection;
    public int moveAnimation;
    private bool ShieldingAnimation = false;
    private bool IsAttacking = false;
    public bool nextLevel2;
    public bool nextLevel3;
    public bool Victory;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compAnimator = GetComponent<Animator>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        if (xDirection != 0 || yDirection != 0) 
        {
            moveAnimation = 1;
        }
        else
        {
            moveAnimation = 0;
        }
        _compAnimator.SetInteger("IsWalkingX", moveAnimation);
        Flip();
        LongAttack();
        ShortAttack();
        if (Input.GetKeyDown(KeyCode.E) && !ShieldingAnimation)
        {
            speedX = 0;
            speedY = 0;
            _compAnimator.SetTrigger("Defense");
            ShieldingAnimation = true;
        }
        else
        {
            speedX = 5;
            speedY = 4;
            ShieldingAnimation = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            speedX = 0;
            speedY = 0;
            _compAnimator.SetBool("Defending", true);
        }
        else
        {
            speedX = 5;
            speedY = 4;
            _compAnimator.SetBool("Defending", false);          
        }
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void LongAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speedX = 0;
            speedY = 0;
            _compAnimator.SetTrigger("Firing");
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            _audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speedX = 5;
            speedY = 4;          
        }
    }
    private void ShortAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            speedX = 0;
            speedY = 0;
            _compAnimator.SetTrigger("Attacking");
            IsAttacking = true;

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            speedX = 5;
            speedY = 4;
            _compAnimator.SetTrigger("Attacking");
            IsAttacking = false;
        }       
    }
    void Flip()
    {
        if (xDirection < 0)
        {
            bullet.facingRight = false;
            _compSpriteRenderer.flipX = true;            
        }
        else if (xDirection > 0)
        {
            bullet.facingRight = true;
            _compSpriteRenderer.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector3(speedX * xDirection, speedY * yDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (IsAttacking == true)
            {
                enemy.enemyHealth = 0;
            }
        }
        if (collision.gameObject.tag == "next2")
        {
            nextLevel2 = true;
        }
        if (collision.gameObject.tag == "next3")
        {
            nextLevel3 = true;
        }
        if (collision.gameObject.tag == "nextvictory")
        {
            Victory = true;
        }
    }
}
