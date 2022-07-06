using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D" + col.gameObject.tag);
        if (col.gameObject.tag == "MacroPredator") {
            Destroy(gameObject);
            // gameObject.GetComponent<Renderer>().material.color.a = 1.0f;
        }
   
    }
}
