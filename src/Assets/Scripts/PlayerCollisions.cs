using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public float destruct_time = 1.5f;
    // Start is called before the first frame update
    AudioManager audioManager;
    public GameObject cam;

    void Awake()
    {
        audioManager = gameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            AudioSource Pred_source = col.gameObject.GetComponent<AudioSource>();
            Pred_source.Stop();

            AudioSource source = cam.GetComponent<AudioSource>();
            source.Stop();

            audioManager.Play("Scream");
            Destroy(gameObject, destruct_time);
            // gameObject.GetComponent<Renderer>().material.color.a = 1.0f;
        }
    }
}
