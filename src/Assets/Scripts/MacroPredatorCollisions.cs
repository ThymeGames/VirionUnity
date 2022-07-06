using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroPredatorCollisions : MonoBehaviour
{

    Animator anim;
    public GameObject darkness;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player") {
            Debug.Log("OnCollisionEnter2D  " + tag);
            Vector3 pos = col.gameObject.transform.position;
            transform.position = pos;
            Instantiate(darkness);
            gameObject.GetComponent<Rigidbody2D>().velocity *= 0f;
            anim.Play("Run", -1, 0f);
        }
    }
}
