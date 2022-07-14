using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{

    public float flyVelocity = 0.5f;

    Rigidbody2D rb;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly() {
        float verticalInput = Input.GetAxis("Vertical"); 
        // Debug.Log(verticalInput.ToString());
        rb.velocity = new Vector2(rb.velocity.x, verticalInput * flyVelocity);
    }

}
