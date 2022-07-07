using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update

    public float alpha_step = 0.01f;
    SpriteRenderer sr;
    Rigidbody2D rb;
    bool isFaded = false;
    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = rb.velocity.magnitude;
        float w = rb.angularVelocity;

        bool isMoving = (v + w > 0);

        if (!isFaded && isMoving) {
            StartCoroutine(Fade_());
        }
        if (sr.material.color.a < 0.005) {
            isFaded = true;
            sr.enabled = false;
        }
    }

    IEnumerator Fade_()
    {
        Color c = sr.material.color;
        for (float alpha = 1f; alpha > 0; alpha -= alpha_step)
        {
            c.a = alpha;
            sr.material.color = c;
            // Debug.Log(alpha.ToString());
            yield return null;  // new WaitForSeconds(.1f);
        }
    }
}
