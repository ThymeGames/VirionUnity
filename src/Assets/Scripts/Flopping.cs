using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flopping : MonoBehaviour
{

    public Vector2 impulse = new Vector2(0.05f, 0.2f);
    public float torque = 1f;
    Rigidbody2D rb;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flop();
    }

    void Flop() {

        string[] keys = new string[] {"up", "space", "w"};
        bool up = false;
        foreach(string key in keys) {
            up |= Input.GetKeyDown(key);
        }

        if (up) {
            // Debug.Log("Jump");
            rb.AddForce(
                impulse,
                ForceMode2D.Impulse
            );
            // rb.AddTorque(
            //     torque * Random.value * Mathf.Sign(rb.angularVelocity),
            //     ForceMode2D.Impulse
            // );
        }    
    }

}
