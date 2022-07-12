using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlopaMovement : MonoBehaviour
{

    public Vector2 impulse = new Vector2(0.05f, 0.2f);
    public float flyVelocity = 0.5f;
    public float torque = 1f;
    public float dashImpulse = 0.2f;

    public Transform FlopaSwitch;
    public Transform FlySwitch;

    public float shrink_y = 3;


    
    // bool isPressed = false;
    Rigidbody2D rb;
    float gravityScale;
    Vector3 scale;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        scale = transform.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        // SwitchToFlying();
        SwitchToFlopping();
    }

    void Update()
    {
        if (transform.position.x < FlopaSwitch.position.x) {
            SwitchToFlopping();
            transform.localScale = scale;

        }
        if (FlySwitch.position.x < transform.position.x) {
            SwitchToFlying();

            Vector3 scale_new = scale;
            scale_new.y /= shrink_y;
            transform.localScale = scale_new;

        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "FlopaSwitch") {
            SwitchToFlopping();
        } else if (col.gameObject.name == "FlySwitch") {
            SwitchToFlying();
        }
    }

    void SwitchToFlopping() {

        rb.gravityScale = gravityScale;

        if (gameObject.GetComponent<Flopping>() == null) {
            Flopping x = gameObject.AddComponent<Flopping>();
            x.impulse = impulse;
            x.torque = torque;

        }

        if (gameObject.GetComponent<Flying>() != null) {
            Destroy(gameObject.GetComponent<Flying>());        
        }

        // Debug.Log("Switched to Flopping");

    }

    void SwitchToFlying() {

            rb.gravityScale = 0;

            if (gameObject.GetComponent<Flying>() == null) {
                Debug.Log("No Flying => I will add one");
                Flying x = gameObject.AddComponent<Flying>();
                x.flyVelocity = flyVelocity;
            }

            if (gameObject.GetComponent<Flopping>() != null) {
                Debug.Log("Delete Flopping");
                Destroy(gameObject.GetComponent<Flopping>());        
            }     

            // Debug.Log("Switched to Flying");
    }

}
