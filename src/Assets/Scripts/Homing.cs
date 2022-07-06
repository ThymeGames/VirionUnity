using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    public Transform target;
    public float velocityMagnitude = 1f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null) {
            return;
        }

        Vector3 target_position = target.position;
        Vector3 direction = target_position - transform.position;
        
        float h = direction.magnitude;

        Vector3 velocity = direction / h * velocityMagnitude;
        // transform.position += velocity * Time.fixedDeltaTime;

        rb.velocity = velocity;

        target_position.x = target_position.x - transform.position.x;
        target_position.y = target_position.y - transform.position.y;

        float angle = Mathf.Atan2(target_position.y, target_position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180f));

    }
}
