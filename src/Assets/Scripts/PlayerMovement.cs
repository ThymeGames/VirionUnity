using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float impulse = 1f;
    public float impulse_cooldown = 1f;  // sec
    public float torque = 1f;
    public float impulse_offset = 0.1f; // sec

    Rigidbody2D rb;
    Animator anim;
    GameObject dream;
    float timer = 0;
    float time_impulse = 0;
    bool anim_locked = false;

    float verticalInput = 0;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.Play("ImpulseForward", -1, 1f);

        foreach(Transform child in transform)
        {
                if(child.tag == "Dream")
                {
                    dream = child.gameObject;
                }
        }    
           
    }

    void Start() {
        Destroy(dream, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyTorque();

        if (IsImpulseAnimationReady()) {
            
            verticalInput = Input.GetAxis("Vertical"); 

            if (verticalInput != 0) {
                anim_locked = true;
                anim.Play("ImpulseForward", -1, 0f);
                time_impulse = timer + impulse_offset;
                // Debug.Log("anim" + timer.ToString());
            }

        } 

        if (IsImpulseReady()) {
            ApplyImpulse();
            // FindObjectOfType<AudioManager>().Play("swimming");
        }

        timer += Time.deltaTime;
    }

    void ApplyTorque() {
        float turn = Input.GetAxis("Horizontal");
        rb.AddTorque(-torque * turn);
    }

    bool IsImpulseAnimationReady() {
        return !anim_locked && (timer >= impulse_cooldown);
    }

    bool IsImpulseReady() {
        return timer >= time_impulse;
    }

    void ApplyImpulse() {

        // float verticalInput = Input.GetAxis("Vertical"); 
        
        if (verticalInput == 0) {
            return;
        }

        if (verticalInput < 0) {
            verticalInput /= 3;
        }

        Quaternion rotation = transform.rotation;
        rb.AddForce(
            rotation * Vector2.up * impulse * verticalInput,
            ForceMode2D.Impulse
        );

        // Debug.Log("impulse" + timer.ToString());

        timer = 0;            
        anim_locked = false;

    }

}
