using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public float destruct_time = 1.5f;
    // Start is called before the first frame update
    AudioManager audioManager;

    float timer = 0f;
    bool isDestroying = false;


    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroying) {
            timer += Time.deltaTime;

            if (timer > destruct_time) {

                Color c = gameObject.GetComponent<SpriteRenderer>().material.color;
                c.a = 0;

                gameObject.GetComponent<SpriteRenderer>().material.color = c;

            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D" + col.gameObject.tag);
        if (col.gameObject.tag == "MacroPredator") {

            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            // Destroy(rb);
            rb.isKinematic = true;
            rb.angularVelocity *= 0;
            rb.velocity *= 0;

            gameObject.GetComponent<Collider2D>().enabled = false;
            audioManager.Play("Scream");

            isDestroying = true;
        }
   
    }
}
