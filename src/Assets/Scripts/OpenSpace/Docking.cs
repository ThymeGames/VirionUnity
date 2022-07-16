using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Docking : MonoBehaviour
{

    public float alpha_step = 0.01f;
    public float repulse = 10f;
    public float repulse_torque = 10f;

    bool _IsNicelyDocked = false;
    Animator anim;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
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
            audioManager.Play("Batz");
            Repulse();
        }

        if ((col.gameObject.tag == "BestCellEver") && !IsNicelyDocked()) {
            Debug.Log("oh my... here we are!");
            audioManager.Play("RightDocking");
            _IsNicelyDocked = true;
            anim.Play("Docking", -1, 0f);
            gameObject.GetComponent<ShutUpCamera>().ShutUp();
            StopEveryThing();
        }
   
    }

    public bool IsNicelyDocked() {
        return _IsNicelyDocked;
    }
    

    void StopEveryThing() {

        GameObject player = gameObject.transform.parent.gameObject;
        GameObject predator = GameObject.FindWithTag("MacroPredator");
        GameObject cell = GameObject.FindWithTag("BestCellEver");

        List<GameObject> objs = new List<GameObject>{player, predator, cell};

        foreach (GameObject obj in objs) {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        predator.GetComponent<AudioSource>().enabled = false;

    }

}
