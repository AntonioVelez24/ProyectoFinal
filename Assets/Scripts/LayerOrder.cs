using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    public GameObject enemy;
    private SpriteRenderer _compSpriteRenderer;
    private void Awake()
    {
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy.transform.position.y > transform.position.y)
        {
            _compSpriteRenderer.sortingOrder = 3;
        }
        else
        {
            _compSpriteRenderer.sortingOrder = 1;
        }
    }
}
