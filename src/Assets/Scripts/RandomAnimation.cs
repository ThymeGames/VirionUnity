using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{

    public float proba = 0.001f;
    public string animation_name = "Idle";
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rand = Random.value;
        if (rand < proba) {
            anim.Play(animation_name, -1, 0f);
        }
    }
}
