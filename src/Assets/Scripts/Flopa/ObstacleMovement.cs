using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float velocity = 1f;
    public float acceleration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity += Time.fixedDeltaTime * acceleration;
        Vector3 translation = Vector3.left * velocity * Time.fixedDeltaTime;
        transform.Translate(translation, Space.World);
    }
}
