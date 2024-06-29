using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator _compAnimator;
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    public GameObject bulletPrefab;
    public float speed;
    public float xDirection;
    public float yDirection;
    public int moveAnimation;
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
        if (Input.GetButtonDown("Fire1") == true)
        {
            _compAnimator.SetTrigger("Firing");
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
    void Flip()
    {
        if (xDirection < 0)
        {
            _compSpriteRenderer.flipX = true;
        }
        else if (xDirection > 0)
        {
            _compSpriteRenderer.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speed * xDirection, speed * yDirection);
    }
}
