using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject objective;
    public float minPositionX;
    public float minPositionY;
    public float maxPositionX;
    public float maxPositionY;
    public float currentPositionX;
    public float currentPositionY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPositionX = Mathf.Clamp(objective.transform.position.x, minPositionX, maxPositionX);
        currentPositionY = Mathf.Clamp(objective.transform.position.y, minPositionY, maxPositionY);
        transform.position = new Vector3(currentPositionX, currentPositionY, -10);
    }
}
