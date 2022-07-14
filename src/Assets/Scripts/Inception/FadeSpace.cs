using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSpace : MonoBehaviour
{
    // Start is called before the first frame update

    public float fadeTime = 2f;

    SpriteRenderer sr;
    bool isFading = false;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (Input.GetKeyDown("space")) {
            isFading = true;
        }

        if (isFading) {
            Fade_();
        }

        if (sr.material.color.a < 0.005) {
            Destroy(gameObject);
        }

    }

    void Fade_()
    {

        Color c = sr.material.color;

        float alpha_drop = Time.deltaTime / fadeTime;
        float alpha = c.a - alpha_drop;
        if (alpha < 0) {
            alpha = 0;
        }
        c.a = alpha;
        sr.material.color = c;

    }
}
