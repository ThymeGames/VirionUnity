using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 impulse;
    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Check collider");
        if (col.gameObject.name == "Player") {
            Debug.Log("Repulse player");
            rb = col.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(impulse, ForceMode2D.Impulse);
        }
    }

}
