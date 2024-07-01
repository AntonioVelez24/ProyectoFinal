using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float directionX = 1;
    public PlayerControl player;    
    public float speed;
    private SpriteRenderer _compSpriteRenderer;    
    public bool facingRight = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this.gameObject, 2);
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (facingRight == true)
        {
            _compSpriteRenderer.flipX = true;
            directionX = 1;
        }
        else
        {
            _compSpriteRenderer.flipX = false;
            directionX = -1;
        }
        transform.position = new Vector3(transform.position.x + speed * directionX * Time.deltaTime, transform.position.y,-1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {            
            Destroy(gameObject);
        }
    }
}
