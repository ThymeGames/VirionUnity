using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Docking : MonoBehaviour
{

    public float repulse = 10f;
    public float repulse_torque = 10f;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Repulse() {
        Quaternion rotation = transform.rotation;

        Rigidbody2D rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        
        rb.AddForce(
            rotation * Vector2.up * repulse * (1 + Random.value),
            ForceMode2D.Impulse
        );

        float turn = Random.value - 0.5f;
        rb.AddTorque(-repulse_torque * turn);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        Debug.Log("Player collider with " + tag);

        if (col.gameObject.tag == "IntactCell") {
            Repulse();
        }

        if (col.gameObject.tag == "BestCellEver") {
            Debug.Log("oh my... here we are!");
            anim.Play("Docking", -1, 0f);
        }
   
    }
    
}
